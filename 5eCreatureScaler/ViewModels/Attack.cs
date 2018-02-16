using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.ViewModels
{
    public sealed class Attack
    {
        public Attack(Models.Attack attack)
        {
            this.Title = attack.Name;

            this.Details = attack.AttackRollAbility.ToString();
        }

        public string Title
        {
            get;
        }

        public string Details
        {
            get;
        }
    }

}