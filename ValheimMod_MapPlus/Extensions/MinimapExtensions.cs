using static Minimap;

namespace Startup.Extensions
{
    public static class MinimapExtensions
    {
        public static PinData AddPin(this Minimap minimap, PinData pin)
        {
            minimap.AddPin(pin.m_pos, pin.m_type, pin.m_name, pin.m_save, pin.m_checked, pin.m_ownerID, pin.m_author);
            return pin;
        }
    }
}
