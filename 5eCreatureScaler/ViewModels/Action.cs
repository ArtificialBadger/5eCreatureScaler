using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreatureScaler.ViewModels
{
    public sealed class Action
    {
        public Action(string title, string details)
        {
            this.Title = title;
            this.Details = details;
        }

        public Action(string title, string attackDetails, string details)
        {
            this.Title = title;
            this.AttackDetails = attackDetails;
            this.Details = details;
        }

        public string Title
        {
            get;
        }

        public string AttackDetails
        {
            get;
        }

        public string Details
        {
            get;
        }
    }

}