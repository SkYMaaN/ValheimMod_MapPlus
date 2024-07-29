using static Minimap;

namespace ValheimMod_MapPlus.Helpers
{
    public static class PinHelper
    {
        public const string MapPlusPinKey = "MapPlusPin";

        public const string CharacterPinKey = "CharacterPin";

        public const string MonsterPinKey = "MonsterPin";

        public const string TameablePinKey = "TameablePin";

        public static PinData CreatePin(Character character)
        {
            var pinData = new PinData()
            {
                m_name = character.GetHoverName(),
                m_pos = character.GetCenterPoint(),
                m_ownerID = character.GetInstanceID(),
                m_author = MapPlusPinKey,
                m_type = PinType.None,
                m_save = false,
            };

            return pinData;
        }
    }
}
