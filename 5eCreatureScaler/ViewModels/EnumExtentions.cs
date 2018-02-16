using System.Collections.Generic;

namespace CreatureScaler.ViewModels
{
    public static class EnumExtentions
    {
        private static IDictionary<Models.Die, string> dieDisplayNameMap = new Dictionary<Models.Die, string>()
        {
            {Models.Die.D2, "d2"},
            {Models.Die.D4, "d4"},
            {Models.Die.D6, "d6"},
            {Models.Die.D8, "d8"},
            {Models.Die.D10, "d10"},
            {Models.Die.D12, "d12"},
            {Models.Die.D20, "d20"},
            {Models.Die.D100, "d100"},
        };

        private static IDictionary<Models.Language, string> languageDisplayNameMap = new Dictionary<Models.Language, string>()
        {
            {Models.Language.DeepSpeech, "Deep Speech" },
            {Models.Language.WhiteWolf, "White Wolf" },
        };

        public static string GetDisplayName(this Models.Die die)
        {
            return dieDisplayNameMap[die];
        }

        public static string GetDisplayForAbility(this int number)
        {
            if (number > 0)
            {
                return $"+{number}";
            }

            return number + "";
        }

        public static string GetDisplayNameForLanguage(this Models.Language language)
        {
            if (languageDisplayNameMap.ContainsKey(language))
            {
                return languageDisplayNameMap[language];
            }
            else
            {
                return language.ToString(); 
            }
        }

    }
}
