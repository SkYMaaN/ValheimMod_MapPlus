//#define LOWPERFOMANCEMODE

using BepInEx;
using HarmonyLib;
using Startup.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ValheimMod_MapPlus.Helpers;
using static Minimap;

namespace ValheimMod_MapPlus
{
    [BepInProcess("valheim.exe")]
    [BepInPlugin("ValheimMod_MapPlus", "Map Plus", "1.0.0")]
    public class MapPlus : BaseUnityPlugin
    {
        private static List<PinData> _pins;

        private static bool _pinUpdateRequired;

        private readonly Harmony _harmony = new Harmony("ValheimMod_MapPlus");

        void Awake()
        {
            Debug.Log("Start loading mode - MapPlus");

            _harmony.PatchAll();

            Debug.Log("Finished loading mode - MapPlus");
        }

        void OnDestroy() => _harmony.UnpatchSelf();

        [HarmonyPatch(typeof(Minimap), "Awake")]
        class MinimapAwakePatch
        {
            [HarmonyPostfix]
            static void MinimapAwake(ref List<PinData> ___m_pins, ref bool ___m_pinUpdateRequired)
            {
                _pins = ___m_pins;
                _pinUpdateRequired = ___m_pinUpdateRequired;

                SpriteHelper.LoadSprites();
            }
        }

#if DEBUG
        //DEBUG helper
        [HarmonyPatch(typeof(Minimap), nameof(Minimap.OnMapMiddleClick))]
        class MinimapDebugPatch
        {
            [HarmonyPostfix]
            static void OnMapMiddleClick(ref List<PinData> ___m_pins, ref bool ___m_pinUpdateRequired)
            {
                _pins = ___m_pins;
                _pinUpdateRequired = ___m_pinUpdateRequired;

                Debug.Log($" Plugin hot reloaded ");
                Debug.Log($" Plugin hot reloaded ");
                Debug.Log($" Plugin hot reloaded ");
                Debug.Log($" Plugin hot reloaded ");
                

                SpriteHelper.LoadSprites();
            }
        }
#endif

        public static void AddOrUpdatePin(Vector3 pos, PinType type, string name, bool save, bool isChecked, long ownerID, string author)
        {
            var existingPin = _pins.FirstOrDefault(p => p.m_ownerID.Equals(ownerID) && p.m_author.Equals(author));

            if (existingPin != null)
            {
#if !LOWPERFOMANCEMODE
                instance.RemovePin(existingPin);
#else
                existingPin.m_pos = pinData.m_pos;
                _pinUpdateRequired = true;
#endif
            }

            instance.AddPin(pos, type, name, save, isChecked, ownerID, author);
        }

        public static void RemovePin(long ownerID, string author)
        {
            var existingPin = _pins.FirstOrDefault(p => p.m_ownerID.Equals(ownerID) && p.m_author.Equals(author));

            if (existingPin != null)
            {
                instance.RemovePin(existingPin);
            }
        }
    }
}
