using HarmonyLib;
using ValheimMod_MapPlus.Helpers;
using static Minimap;

namespace ValheimMod_MapPlus.Patches
{
    class PinPatches
    {
        [HarmonyPatch(typeof(Minimap), nameof(Minimap.AddPin))]
        class AddPinPatch
        {
            [HarmonyPostfix]
            static void SetPinSprite(PinData __result)
            {
                if(__result.m_icon != null)
                {
                    return;
                }

                __result.m_icon = SpriteHelper.GetSpriteByPinName(__result.m_name);
            }
        }
    }
}
