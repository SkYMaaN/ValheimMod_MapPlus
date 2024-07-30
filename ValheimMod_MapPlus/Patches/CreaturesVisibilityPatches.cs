using HarmonyLib;
using ValheimMod_MapPlus.Constants;

namespace ValheimMod_MapPlus.Patches
{
    class CreaturesVisibilityPatches
    {
        [HarmonyPatch(typeof(MonsterAI), nameof(MonsterAI.UpdateAI))]
        class MonsterAIOnUpdatePatch
        {
            [HarmonyPostfix]
            static void UpdateMonsterAIPin(ref bool __result, ref Character ___m_character) => UpdateCreaturePin(ref __result, ref ___m_character);
        }

        [HarmonyPatch(typeof(AnimalAI), nameof(AnimalAI.UpdateAI))]
        class AnimalAIOnUpdatePatch
        {
            [HarmonyPostfix]
            static void UpdateAnimalAIPin(ref bool __result, ref Character ___m_character) => UpdateCreaturePin(ref __result, ref ___m_character);
        }

        [HarmonyPatch(typeof(Character), "OnDeath")]
        class CreatureOnDeathPatch
        {
            [HarmonyPostfix]
            static void RemoveCreaturePin(ref Character __instance)
            {
                MapPlus.RemovePin(__instance.GetInstanceID(), MapPlusConstants.PinKey);
            }
        }

        private static void UpdateCreaturePin(ref bool __result, ref Character ___m_character)
        {
            if (__result)
            {
                MapPlus.AddOrUpdatePin(___m_character.transform.position, Minimap.PinType.None, ___m_character.GetHoverName(), false, false, ___m_character.GetInstanceID(), MapPlusConstants.PinKey);
            }
            else
            {
                MapPlus.RemovePin(___m_character.GetInstanceID(), MapPlusConstants.PinKey);
            }
        }
    }
}
