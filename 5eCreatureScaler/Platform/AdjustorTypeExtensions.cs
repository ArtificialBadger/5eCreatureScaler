namespace CreatureScaler.Platform
{
    public static class AdjustorTypeExtensions
    {
        public static bool IsDefensiveType(this AdjustorType type)
        {
            switch (type)
            {
                case AdjustorType.AC:
                case AdjustorType.Defenses:
                case AdjustorType.HitPoints:
                case AdjustorType.Constitution:
                case AdjustorType.Dexterity:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsOffensiveType(this AdjustorType type)
        {
            switch (type)
            {
                case AdjustorType.Attacks:
                case AdjustorType.Strength:
                case AdjustorType.Dexterity:
                    return true;
                default:
                    return false;
            }
        }
    }
}