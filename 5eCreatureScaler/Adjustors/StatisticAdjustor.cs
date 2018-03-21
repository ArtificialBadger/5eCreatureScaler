using CreatureScaler.Models;
using CreatureScaler.Platform;
using CreatureScaler.Rules;
using CreatureScaler.RuleTokens;
using System.Linq;

namespace CreatureScaler.Adjustors
{
    public sealed class StatisticAdjustor : ICreatureAdjustor
    {
        private readonly Ability abilityToModify;

        public StatisticAdjustor(Ability abilityToModify)
        {
            this.abilityToModify = abilityToModify;
        }

        public uint EstimatedAdjustmentDistance => 1;

        public void AdjustUp(Creature creature)
        {
            creature.Statistics.First(f => f.Ability == abilityToModify).Value += 2;
        }
        public void AdjustDown(Creature creature)
        {
            creature.Statistics.First(f => f.Ability == abilityToModify).Value -= 2;
        }

        public bool Qualified(Creature creature)
        {
            if (abilityToModify == Ability.Dexterity)
            {
                return true;
            }

            return 
                creature.Actions.Any(action => action.RulesText.Get<AttackToken>(token => token.Ability == abilityToModify).Any())
                ||
                creature?.InnateSpellcasting?.SpellcastingAbility == abilityToModify
                ||
                creature?.Spellcasting?.SpellcastingAbility == abilityToModify;
        }
    }
}
