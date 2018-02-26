using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            this.HitPoints = $"{creature.Health.HitPointMaximum} ({creature.Health.HitDieCount}{creature.Health.HitDieSize.GetDisplayName()} + {creature.Health.HitDieCount * creature.Statistics.FirstOrDefault(score => score.Ability == Models.Ability.Constitution)?.Modifier ?? 0}) ";
            
            this.Speed = String.Join(", ", creature.Speeds.Select(s => $"{s.Type}{s.Feet}ft."));

            this.Statistics.Add("STR", creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Strength).Value.ToString());
            this.Statistics.Add("DEX", creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Dexterity).Value.ToString());
            this.Statistics.Add("CON", creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Constitution).Value.ToString());
            this.Statistics.Add("INT", creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Intelligence).Value.ToString());
            this.Statistics.Add("WIS", creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Wisdom).Value.ToString());
            this.Statistics.Add("CHA", creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Charisma).Value.ToString());

            this.DamageImmunities = String.Join(", ", creature.DamageImmunities.Select(di => di.ToString()));
            this.DamageResistances = String.Join(", ", creature.DamageResistances.Select(dr => dr.ToString()));
            this.ConditionImmunities = String.Join(", ", creature.ConditionImmunities.Select(ci => ci.ToString()));
            this.Senses = String.Join(", ", creature.Senses.Select(s => $"{s.SenseType} {s.Range}ft."));
            this.Languages = String.Join(", ", creature.Languages.Select(l => l.GetDisplayName()));
            this.Challenge = $"{creature.ChallengeRating.ListedChallengeRating} ({100}XP)" ;
            
            this.Features = creature.Features.Select(f => new Feature(f)).ToList();

            foreach (var action in creature.Actions)
            {
                this.AddAction(action, creature);
            }

            foreach (var attack in creature.Attacks)
            {
                this.AddAction(attack, creature);
            }

        }

        public string Title { get; }
    
        public string Subtitle { get; }

        public string ArmorClass { get; }
    
        public string HitPoints { get; }
    
        public string Speed { get; }
    
        public IDictionary<string, string> Statistics { get; } = new Dictionary<string, string>();

        public string DamageImmunities { get; }

        public string DamageResistances { get; }
        
        public string ConditionImmunities { get; }

        public string Senses { get; }

        public string Languages { get; }

        public string Challenge { get; }

        public IList<Feature> Features { get; } = new List<Feature>();

        public IList<Action> Actions { get; } = new List<Action>();
    
        private void AddAction(Models.Action action, Models.Creature creature)
        {
            var creatureAction = new Action(action.Name, action.Description);
            this.Actions.Add(creatureAction);
        }

        private void AddAction(Models.Attack attack, Models.Creature creature)
        {
            var detailsBuilder = new StringBuilder();

            var attackModifier = creature.Statistics.First(s => s.Ability == attack.AttackRollAbility).Modifier + creature.ProficiencyBonus;

            detailsBuilder.Append($"{attackModifier.GetDisplayForAbility()} to hit, ");
            detailsBuilder.Append($"reach {attack.Reach}ft., ");
            detailsBuilder.Append($"one target. ");
            
            detailsBuilder.Append("Hit: ");

            detailsBuilder.Append(String.Join(", plus ", attack.DamageRolls.Select(damageRoll => $"{damageRoll.ToAverageDamage()} ({damageRoll.DamageDieCount}{damageRoll.DamageDie.GetDisplayName()} + {creature.Statistics.FirstOrDefault(s => s.Ability == damageRoll.AbilityModifier)?.Modifier ?? 0}) {damageRoll.DamageType} damage")));

            var creatureAttack = new Action(attack.Name, attack.AttackType.GetDisplayName(), detailsBuilder.ToString());
            this.Actions.Add(creatureAttack);
        }
    }
        
}