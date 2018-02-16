﻿using System;
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