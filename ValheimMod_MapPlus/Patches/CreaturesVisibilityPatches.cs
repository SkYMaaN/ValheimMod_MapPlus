using HarmonyLib;
using ValheimMod_MapPlus.Helpers;

namespace ValheimMod_MapPlus.Patches
{
    class CreaturesVisibilityPatches
    {
        [HarmonyPatch(typeof(BaseAI), nameof(BaseAI.UpdateAI))]
        class CreatureStopMovingPatch
        {
            [HarmonyPostfix]
            static void OnMoveTowards(ref Character ___m_character)
            {
                var pin = PinHelper.CreatePin(___m_character);

                MapPlus.AddOrUpdatePin(pin);
            }
        }

        ///TODO: Remove pin when creature dead
    }
}
