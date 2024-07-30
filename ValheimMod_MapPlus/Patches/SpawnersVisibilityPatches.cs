using HarmonyLib;
using UnityEngine;
using ValheimMod_MapPlus.Helpers;

namespace ValheimMod_MapPlus.Patches
{
    class SpawnersVisibilityPatches
    {
        //[HarmonyPatch(typeof(CreatureSpawner), "Awake")]
        class SpawneOnAwakePatch
        {
            [HarmonyPostfix]
            static void AddSpawnerPin(CreatureSpawner __instance)
            {
                
            }
        }
    }
}
