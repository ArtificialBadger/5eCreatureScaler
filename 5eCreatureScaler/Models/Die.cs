using System;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public static class DieExtensions
    {
        private static Dictionary<Die, double> averageValueMap = new Dictionary<Die, double>
        {
            { Die.D2, 1.5 },
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

        public static Die ToDie(this string value)
        {
            return (Die)Convert.ToInt32(value);
        }

        public static Die ToDie(this int value)
        {
            return (Die)value;
        }

        public static Die StepUp(this Die die)
        {
            switch (die)
            {
                case Die.D2:
                    return Die.D4;
                case Die.D4:
                    return Die.D6;
                case Die.D6:
                    return Die.D8;
                case Die.D8:
                    return Die.D10;
                case Die.D10:
                    return Die.D12;
                case Die.D12:
                    return Die.D20;
                default:
                    return die;
            }
        }

        public static Die StepDown(this Die die)
        {
            switch (die)
            {
                case Die.D20:
                    return Die.D12;
                case Die.D12:
                    return Die.D10;
                case Die.D10:
                    return Die.D8;
                case Die.D8:
                    return Die.D6;
                case Die.D6:
                    return Die.D4;
                case Die.D4:
                    return Die.D2;
                default:
                    return die;
            }
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
