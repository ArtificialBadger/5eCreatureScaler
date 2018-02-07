namespace CreatureScaler.Models
{
    public class DamageRoll
    {
        public Die DamageDie { get; set; }
        public int DamageDieCount { get; set; }
        public Ability AbilityModifier { get; set; }
    }
}