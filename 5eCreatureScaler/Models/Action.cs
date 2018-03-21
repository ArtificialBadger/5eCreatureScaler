using CreatureScaler.Rules;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public sealed class Action
    {
        public string Name 
        { 
            get; 
            set; 
        }

        public IDictionary<string, int> MultiGroups 
        { 
            get; 
            set; 
        } = new Dictionary<string, int>();

        public RulesText RulesText
        {
            get;
            set;
        }

        public string Recharge
        {
            get;
            set;
        }

        public double CalculateDamagePerRound(Creature creature)
        {
            return this.RulesText.AverageDamage(creature);
        }
    }
}
