using CreatureScaler.Models;
using CreatureScaler.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreatureScaler.ViewModels
{
    public sealed class CreatureViewModel
    {
        public CreatureViewModel(Models.Creature creature)
        {
            this.Model = creature;
            this.Title = creature.Name;
            this.Subtitle = $"{creature.Size} {creature.Type}, {creature.Alignment.GetDisplayName()}";

            if (String.IsNullOrWhiteSpace(creature.ArmorClass.Description))
            {
                this.ArmorClass = $"{creature.ArmorClass.Value + creature.Statistics.ByAbility(Ability.Dexterity)?.Modifier ?? 0}";
            }
            else
            {
                this.ArmorClass = $"{creature.ArmorClass.Value + creature.Statistics.ByAbility(Ability.Dexterity)?.Modifier ?? 0} ({creature.ArmorClass.Description})";
            }

            this.HitPoints = $"{creature.Health} ({creature.HitDieCount}{creature.Size.ToHitDie().GetDisplayName()} + {creature.HitDieCount * creature.Statistics.FirstOrDefault(score => score.Ability == Models.Ability.Constitution)?.Modifier ?? 0}) ";

            this.Speed = String.Join(", ", creature.Speeds.Select(s => $"{s.Mode.GetDisplayName()}{s.Distance}ft."));

            this.Statistics.Add("STR", $"{creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Strength).Value} ({creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Strength).Modifier.GetDisplayForAbility()})");
            this.Statistics.Add("DEX", $"{creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Dexterity).Value} ({creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Dexterity).Modifier.GetDisplayForAbility()})");
            this.Statistics.Add("CON", $"{creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Constitution).Value} ({creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Constitution).Modifier.GetDisplayForAbility()})");
            this.Statistics.Add("INT", $"{creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Intelligence).Value} ({creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Intelligence).Modifier.GetDisplayForAbility()})");
            this.Statistics.Add("WIS", $"{creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Wisdom).Value} ({creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Wisdom).Modifier.GetDisplayForAbility()})");
            this.Statistics.Add("CHA", $"{creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Charisma).Value} ({creature.Statistics.FirstOrDefault(s => s.Ability == Models.Ability.Charisma).Modifier.GetDisplayForAbility()})");

            this.DamageImmunities = String.Join(", ", creature.DamageImmunities.Select(di => di.ToString()));
            this.DamageResistances = String.Join(", ", creature.DamageResistances.Select(dr => dr.ToString()));
            this.ConditionImmunities = String.Join(", ", creature.ConditionImmunities.Select(ci => ci.ToString()));
            this.Senses = String.Join(", ", creature.Senses.Select(s => $"{s.SenseType} {s.Range}ft."));
            this.Languages = String.Join(", ", creature.Languages.Select(l => l.GetDisplayName()));
            this.Challenge = $"{creature.ChallengeRating.ListedChallengeRating} ({creature.ChallengeRating.ExperiencePoints} XP)" ;
            
            this.Features = creature.Features.Select(f => new Feature(f)).ToList();

            this.AddMultiattack(creature);

            //foreach (var attack in creature.Attacks)
            //{
            //    this.AddAction(attack);
            //}

            foreach (var action in creature.Actions)
            {
                this.AddAction(action);
            }
        }

        public Models.Creature Model { get; }

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

        private void AddAction(RulesText action)
        {
            if (!String.IsNullOrWhiteSpace(action.Recharge))
            {
                this.Actions.Add(new Action($"{action.Name} (Recharge {action.Recharge})", action.Format(this.Model)));
            }
            else
            {
                this.Actions.Add(new Action(action.Name, action.Format(this.Model)));
            }
        }

        private void AddMultiattack(Models.Creature creature)
        {
            var multiAttackGroups = new Dictionary<string, List<(string, int)>>();
            if (creature.Actions.Any(a => a.MultiGroups.Any()) || creature.Actions.Any(a => a.MultiGroups.Any()))
            {
                foreach (var action in creature.Actions)
                {
                    foreach (var multiAttack in action.MultiGroups)
                    {
                        if (!multiAttackGroups.ContainsKey(multiAttack.Key))
                        {
                            multiAttackGroups.Add(multiAttack.Key, new List<(string, int)>());
                        }

                        multiAttackGroups[multiAttack.Key].Add((action.Name, multiAttack.Value));
                    }
                    
                }

                foreach (var attack in creature.Attacks)
                {
                    foreach (var multiAttack in attack.MultiGroups)
                    {
                        if (!multiAttackGroups.ContainsKey(multiAttack.Key))
                        {
                            multiAttackGroups.Add(multiAttack.Key, new List<(string, int)>());
                        }

                        multiAttackGroups[multiAttack.Key].Add((attack.Name, multiAttack.Value));
                    }
                }

                var multiGroupDescriptions = new List<string>();

                foreach (var multiAttackGroup in multiAttackGroups)
                {
                    var multiAttackDescriptions = new List<string>();

                    var orderedMultiAttackGroups = multiAttackGroup.Value.OrderBy(f => f.Item2);
                    foreach (var group in orderedMultiAttackGroups)
                    {
                        if (group.Item2 > 1)
                        {
                            multiAttackDescriptions.Add($"{group.Item2.GetNaturalName()} {group.Item1.ToLowerInvariant()} attacks");
                        }
                        else
                        {
                            multiAttackDescriptions.Add($"{group.Item2.GetNaturalName()} {group.Item1.ToLowerInvariant()} attack");
                        }
                    }

                    multiGroupDescriptions.Add(String.Join(" and ", multiAttackDescriptions));
                }

                Actions.Add(new Action("Multiattack", $"The {creature.Name.ToLowerInvariant()} makes {String.Join(" or ", multiGroupDescriptions)}"));
            }
        }

        private void AddAction(Models.Attack attack, Models.Creature creature)
        {
            var detailsBuilder = new StringBuilder();

            var attackModifier = creature.Statistics.First(s => s.Ability == attack.AttackRollAbility).Modifier + creature.ProficiencyBonus;

            detailsBuilder.Append($"{attackModifier.GetDisplayForAbility()} to hit, ");
            detailsBuilder.Append($"reach {attack.Reach}ft., ");
            detailsBuilder.Append($"one target. ");

            detailsBuilder.Append("Hit: ");

            var damageRollDisplays = new List<string>();

            foreach (var damageRoll in attack.DamageRolls)
            {
                var damageModifier = creature.Statistics.FirstOrDefault(s => s.Ability == damageRoll.AbilityModifier)?.Modifier ?? 0;
                if (damageModifier != 0)
                {
                    damageRollDisplays.Add($"{damageRoll.ToAverageDamage() + damageModifier} ({damageRoll.DamageDieCount}{damageRoll.DamageDie.GetDisplayName()} + {damageModifier}) {damageRoll.DamageType.ToString().ToLowerInvariant()} damage");
                }
                else
                {
                    damageRollDisplays.Add($"{damageRoll.ToAverageDamage()} ({damageRoll.DamageDieCount}{damageRoll.DamageDie.GetDisplayName()}) {damageRoll.DamageType.ToString().ToLowerInvariant()} damage");
                }
            }

            detailsBuilder.Append(String.Join(", plus ", damageRollDisplays));

            var creatureAttack = new Action(attack.Name, attack.AttackType.GetDisplayName(), detailsBuilder.ToString());
            this.Actions.Add(creatureAttack);
        }
    }
        
}