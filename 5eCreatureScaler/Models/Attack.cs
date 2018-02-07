using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public class Attack
    {
        public string Name { get; set; }
        public List<DamageRoll> DamageRolls { get; set; } = new List<DamageRoll>();
        public Ability AttackRollAbility { get; set; }
        public int Reach { get; set; }
        public int MaximumAttacksPerRound { get; set; }
    }
}