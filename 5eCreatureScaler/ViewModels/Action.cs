using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.ViewModels
{
    public sealed class Action
    {
        public Action(Models.Action action)
        {
            this.Title = action.Name;
            this.Details = action.Description;
        }

        public Action(Models.Attack attack)
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