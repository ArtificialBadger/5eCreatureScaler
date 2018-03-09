﻿using CreatureScaler.Models;
using CreatureScaler.Platform;
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
                creature.Attacks.Any(attack => attack.AttackRollAbility == abilityToModify)
                ||
                creature?.InnateSpellcasting?.SpellcastingAbility == abilityToModify
                ||
                creature?.Spellcasting?.SpellcastingAbility == abilityToModify;
        }
    }
}