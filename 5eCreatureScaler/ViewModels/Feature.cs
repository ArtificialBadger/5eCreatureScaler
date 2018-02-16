using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.ViewModels
{
    public sealed class Feature
    {
        public Feature(Models.Feature feature)
        {
            this.Title = feature.Name;
            this.Details = feature.Description;
        }

        public string Title { get; }

        public string Details { get; }

    }

}