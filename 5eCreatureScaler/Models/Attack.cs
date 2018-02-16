using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public class Attack : Action
    {
        public List<DamageRoll> DamageRolls 
        { 
            get; 
            set; 
        } = new List<DamageRoll>();
        
        public Ability AttackRollAbility 
        { 
            get; 
            set; 
        }
        
        public int Reach 
        { 
            get; 
            set; 
        }

        public override int CalculateDamagePerRound()
        {
            return 0;
        }
    }
}