namespace CreatureScaler.Models
{
    public class ProficiencyModifier
    {
        public ProficiencyModifier CreateWithStaticProficiency(int proficiencyModifier)
        {
            return new ProficiencyModifier(false, proficiencyModifier);
        }

        public ProficiencyModifier CreateCalculatedByChallengeRating(int challengeRating)
        {
            return new ProficiencyModifier(true, ((challengeRating - 1) / 4) + 2);
        }

        private ProficiencyModifier(bool calculateAutomatically, int modifier)
        {
            this.AutomaticallyDeterminedProficiencyBonus = calculateAutomatically;
            this.ProficiencyBonus = modifier;
        }

        public bool AutomaticallyDeterminedProficiencyBonus { get; }

        public int ProficiencyBonus { get; }
    }
}