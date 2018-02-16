using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.ViewModels
{
    public sealed class Creature
    {
        public Creature(Models.Creature creature)
        {
            this.Title = creature.Name;
            this.Subtitle = $"{creature.Size} {creature.Type}, {creature.Alignment}";

            if (String.IsNullOrWhiteSpace(creature.ArmorClass.Description))
            {
                this.ArmorClass = $"{creature.ArmorClass.Value}";
            }
            else
            {
                this.ArmorClass = $"{creature.ArmorClass.Value} ({creature.ArmorClass.Description})";
            }

            this.HitPoints = $"{creature.Health.HitPointMaximum}";

        }

        public string Title { get; }
    
        public string Subtitle { get; }

        public string ArmorClass { get; }
    
        public string HitPoints { get; }
    
        public string Speed { get; }
    
        public IDictionary<string, string> Stats { get; }

        public string DamageImmunities { get; }

        public string ConditionImmunities { get; }

        public string Senses { get; }

        public string Languages { get; }

        public string Challenge { get; }

        public IList<Feature> Features { get; }

        public IList<Action> Actions { get; }
    }
        
}