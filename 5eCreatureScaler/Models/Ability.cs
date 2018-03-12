namespace CreatureScaler.Models
{
    public enum Ability
    {
        None,
        Strength,
        Dexterity,
        Constitution,
        Intelligence,
        Wisdom,
        Charisma,
        Honor,
        Sanity,
    }
    public static class AbilityExtensions
    {
        public static string ToShorthand(this Ability ability)
        {
            switch (ability)
            {
                case Ability.Strength:
                    return "str";
                case Ability.Dexterity:
                    return "dex";
                case Ability.Constitution:
                    return "con";
                case Ability.Intelligence:
                    return "int";
                case Ability.Wisdom:
                    return "wis";
                case Ability.Charisma:
                    return "cha";
                default:
                    return ability.ToString().ToLower();
            }
        }
    }
}
