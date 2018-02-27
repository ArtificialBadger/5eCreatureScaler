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

        public string Description
        {
            get;
            set;
        }

        public string Recharge
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
