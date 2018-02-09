using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public static class EnumExtentions
    {
        private static IDictionary<Die, string> dieNiceNameMap = new Dictionary<Die, string>()
        {
            {Die.D2, "d2"},
            {Die.D4, "d4"},
            {Die.D6, "d6"},
            {Die.D8, "d8"},
            {Die.D10, "d10"},
            {Die.D12, "d12"},
            {Die.D20, "d20"},
            {Die.D100, "d100"},
        };

        public static string GetNiceName(this Die die)
        {
            return dieNiceNameMap[die];
        }

        public static string GetDisplayForAbility(this int number)
        {
            if (number > 0)
            {
                return $"+{number}";
            }

            return number + "";
        }

    }
}
