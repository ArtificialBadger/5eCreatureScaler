using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public class OtherAction : Action
    {
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

        public override int CalculateDamagePerRound()
        {
            return 0;
        }
    }
}
