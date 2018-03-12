using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public static class DieExtensions
    {
        private static Dictionary<Die, double> averageValueMap = new Dictionary<Die, double>
        {
            { Die.D2, .5 },
            { Die.D4, 2.5 },
            { Die.D6, 3.5 },
            { Die.D8, 4.5 },
            { Die.D10, 5.5 },
            { Die.D12, 6.5 },
            { Die.D20, 10.5 },
            { Die.D100, 50.5 },
        };

        public static double ToAverageValue(this Die die)
        {
            return averageValueMap[die];
        }
    }

    public enum Die
    {
        D2 = 2,
        D4 = 4,
        D6 = 6,
        D8 = 8,
        D10 = 10,
        D12 = 12,
        D20 = 20,
        D100 = 100,
    }
}
