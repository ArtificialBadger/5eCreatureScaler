using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public static class SizeExtensions
    {
        private static Dictionary<Size, Die> SizeToDieMap = new Dictionary<Size, Die>
        {
            { Size.Tiny, Die.D4 },
            { Size.Small, Die.D6 },
            { Size.Medium, Die.D8 },
            { Size.Large, Die.D10 },
            { Size.Huge, Die.D12 },
            { Size.Gargantuan, Die.D20 },
        };

        public static Die ToHitDie(this Size size)
        {
            return SizeToDieMap[size];
        }
    }

    public enum Size
    {
        Tiny,
        Small,
        Medium,
        Large,
        Huge,
        Gargantuan
    }
}
