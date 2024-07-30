using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using ValheimMod_MapPlus.Constants;
using SpriteData = Minimap.SpriteData;
using PinType = Minimap.PinType;

namespace ValheimMod_MapPlus.Helpers
{
    public static class SpriteHelper
    {
        static List<SpriteData> _sprites;

        static SpriteHelper() => LoadSprites();

        public static void LoadSprites()
        {
            var resourceType = typeof(Properties.Resources);

            PropertyInfo[] properties = resourceType.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            _sprites = properties.Where(p => p.PropertyType.Equals(typeof(Bitmap)))
                .Select(p => new SpriteData()
                {
                    m_name = PinType.None,
                    m_icon = BitmapToSprite(p.Name, (Bitmap)p.GetValue(p))
                })
                .ToList();
        }

        public static Sprite GetSpriteByPinName(string pinName)
        {
            Sprite sprite = null;

            switch (pinName)
            {
                case "Boar":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Equals(SpriteNameConstans.Boar)).m_icon;
                        break;
                    }
                case "Deer":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Equals(SpriteNameConstans.Deer)).m_icon;
                        break;
                    }
                case "Wolf":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Equals(SpriteNameConstans.Wolf)).m_icon;
                        break;
                    }
                case "Hare":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Equals(SpriteNameConstans.Hare)).m_icon;
                        break;
                    }
                case "Skeleton":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Skeleton)).m_icon;
                        break;
                    }
                case "Surtling":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Surtling)).m_icon;
                        break;
                    }
                case "Goblin":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Goblin)).m_icon;
                        break;
                    }
                case "Golem":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Golem)).m_icon;
                        break;
                    }
                case "Greydwarf":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Greydwarf)).m_icon;
                        break;
                    }
                case "Growth":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Growth)).m_icon;
                        break;
                    }
                case "Greyling":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Greyling)).m_icon;
                        break;
                    }
                case "Serpent":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Serpent)).m_icon;
                        break;
                    }
                case "Frost Troll":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.FrostTroll)).m_icon;
                        break;
                    }
                case "Hatchling":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Hatchling)).m_icon;
                        break;
                    }
                case "Leech":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Leech)).m_icon;
                        break;
                    }
                case "Forest Troll":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.ForestTroll)).m_icon;
                        break;
                    }
                case "Fenring":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Fenring)).m_icon;
                        break;
                    }
                case "Dvergr":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Dvergr)).m_icon;
                        break;
                    }
                case "Bonemass":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Bonemass)).m_icon;
                        break;
                    }
                case "Dragon Queen":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.DragonQueen)).m_icon;
                        break;
                    }
                case "Goblin Shaman":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.GoblinShaman)).m_icon;
                        break;
                    }
                case "Greydwarf Brute":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.GreydwarfBrute)).m_icon;
                        break;
                    }
                case "Draugr Elite":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.DraugrElite)).m_icon;
                        break;
                    }
                case "Seeker":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Seeker)).m_icon;
                        break;
                    }
                case "The Elder":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.TheElder)).m_icon;
                        break;
                    }
                case "Goblin Brute":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.GoblinBrute)).m_icon;
                        break;
                    }
                case "Death Squito":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.DeathSquito)).m_icon;
                        break;
                    }
                case "Seeker Queen":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.SeekerQueen)).m_icon;
                        break;
                    }
                case "Skeleton Poison":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.SkeletonPoison)).m_icon;
                        break;
                    }
                case "Draugr Fem":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.DraugrFem)).m_icon;
                        break;
                    }
                case "Greydwarf Shaman":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.GreydwarfShaman)).m_icon;
                        break;
                    }
                case "Tick":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Tick)).m_icon;
                        break;
                    }
                case "Cultist":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Cultist)).m_icon;
                        break;
                    }
                case "Seeker Brute":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.SeekerBrute)).m_icon;
                        break;
                    }
                case "Draugr":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Draugr)).m_icon;
                        break;
                    }
                case "Goblin King":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.GoblinKing)).m_icon;
                        break;
                    }
                case "Blob":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Blob)).m_icon;
                        break;
                    }
                case "Neck":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Neck)).m_icon;
                        break;
                    }
                case "Eikthyr":
                    {
                        sprite = _sprites.FirstOrDefault(s => s.m_icon.name.Contains(SpriteNameConstans.Eikthyr)).m_icon;
                        break;
                    }
                default:
                    {
                        Debug.Log($"Not found texture for {pinName} entity!");
                        break;
                    }
            }

            return sprite;
        }


        private static Sprite BitmapToSprite(string spriteName, Bitmap bitmap, float pixelsPerUnit = 100.0f)
        {
            byte[] bitmapBytes = BitmapToBytes(bitmap);

            Texture2D texture = new Texture2D(bitmap.Width, bitmap.Height);
            texture.LoadImage(bitmapBytes);

            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), pixelsPerUnit);
            sprite.name = spriteName;

            return sprite;
        }

        private static byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (var memoryStream = new MemoryStream())
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                return memoryStream.ToArray();
            }
        }
    }
}
