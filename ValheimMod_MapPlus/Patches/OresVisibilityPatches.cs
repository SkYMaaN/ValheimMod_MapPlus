using HarmonyLib;
using ValheimMod_MapPlus.Helpers;

namespace ValheimMod_MapPlus.Patches
{
    class OresVisibilityPatches
    {
        //[HarmonyPatch(typeof(MineRock), "Start")]
        class MineRockOnStartPatch
        {
            [HarmonyPostfix]
            static void AddOreRootPin(MineRock __instance)
            {
                
            }
        }
    }
}
