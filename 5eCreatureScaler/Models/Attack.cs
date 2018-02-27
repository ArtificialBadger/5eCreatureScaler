using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public sealed class Attack
    {
        public string Name
        {
            get;
            set;
        }

        public AttackType AttackType 
        {
            get;
            set;
        }

        public IDictionary<string, int> MultiGroups 
        { 
            get; 
            set; 
        } = new Dictionary<string, int>();

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

        public int CalculateDamagePerRound()
        {
            return 0;
        }
    }
}