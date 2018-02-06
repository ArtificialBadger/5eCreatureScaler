namespace CreatureScaler.Models
{
    public class Attack
    {
        public string Name { get; set; }
        public Die DamageDie { get; set; }
        public int DamageDieCount { get; set; }
        public AbilityScore AbilityModifier { get; set; }


    }
}