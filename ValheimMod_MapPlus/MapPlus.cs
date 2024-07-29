//#define LOWPERFOMANCEMODE

using BepInEx;
using HarmonyLib;
using Startup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Minimap;

namespace ValheimMod_MapPlus
{
    [BepInProcess("valheim.exe")]
    [BepInPlugin("ValheimMod_MapPlus", "Map Plus", "1.0.0")]
    public class MapPlus : BaseUnityPlugin
    {
        private static Minimap _minimap;

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
        class MinimapAwakePatche
        {
            [HarmonyPostfix]
            static void MinimapAwake(ref Minimap ___m_instance, ref List<PinData> ___m_pins, ref bool ___m_pinUpdateRequired)
            {
                _minimap = ___m_instance;
                _pins = ___m_pins;
                _pinUpdateRequired = ___m_pinUpdateRequired;

#if DEBUG
                Debug.Log("\n\n");
                Debug.Log($"MapInstace id: {___m_instance.GetInstanceID()}");
                Debug.Log($"Pins is null: {_pins == null}");
                Debug.Log($"Pin update required: {_pinUpdateRequired}");
                Debug.Log("\n");
#endif
            }
        }

        public static void AddOrUpdatePin(PinData pinData)
        {
            var existingPin = _pins.FirstOrDefault(p => p.m_ownerID.Equals(pinData.m_ownerID) && p.m_author.Equals(pinData.m_author));

            if (existingPin != null)
            {
#if !LOWPERFOMANCEMODE
                _minimap.RemovePin(existingPin);
#else
                existingPin.m_pos = pinData.m_pos;
                _pinUpdateRequired = true;
#endif
            }

            _minimap.AddPin(pinData);
        }

        public static void RemovePin(PinData pinData)
        {
            var existingPin = _pins.FirstOrDefault(p => p.m_ownerID.Equals(pinData.m_ownerID) && p.m_author.Equals(pinData.m_author));

            if (existingPin != null)
            {
                _minimap.RemovePin(pinData);
            }
        }
    }
}
