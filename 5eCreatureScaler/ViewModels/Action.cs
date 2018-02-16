using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.ViewModels
{
    public sealed class Action
    {
        public static Action Create(Models.Action action)
        {
            if (action is Models.Attack)
            {
                return new Action(action as Models.Attack);
            }
            else if (action is Models.OtherAction)
            {
                return new Action(action as Models.OtherAction);
            }
            else
            {
                return null;
            }
        }

        public Action(Models.Attack attack)
        {
            this.Title = attack.Name;

            this.Details = attack.AttackRollAbility.ToString();
        }

        public Action(Models.OtherAction action)
        {
            if (String.IsNullOrWhiteSpace(action.Recharge))
            {
                this.Title = $"{action.Name}.";
            }
            else
            {
                this.Title = $"{action.Name} ({action.Recharge}).";
            }

            this.Details = action.Description;
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