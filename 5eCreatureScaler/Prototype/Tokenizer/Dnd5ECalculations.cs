using CreatureScaler.Models;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Prototype.Tokenizer
{
    public static class Dnd5ECalculations
    {
        public static string ToModString(this (string abilityScoreName, bool proficient) suggestion)
        {
            (var abilityScoreName, var proficient) = suggestion;
            
            var proficiencyString = proficient ? "+p" : string.Empty;

            return string.IsNullOrWhiteSpace(abilityScoreName.ToString()) ? default(string) : $"{abilityScoreName.ToString()}{proficiencyString}";
        }

        public static IEnumerable<string> FindMatchingStatistics(this Creature creature, int bonus)
        {
            return creature
                .Statistics
                .Where(s => s.Modifier == bonus)
                .Select(s => s.Ability.ToShorthand());
        }

        public static IEnumerable<(string abilityScoreName, bool proficient)> FindMatchingStatisticsWithProficiency(this Creature creature, int bonus)
        {
            foreach (var statistic in creature.Statistics)
            {
                if (statistic.Modifier == bonus)
                {
                    yield return (statistic.Ability.ToShorthand(), false);
                }
                
                if (statistic.Modifier + creature.ProficiencyBonus == bonus)
                {
                    yield return (statistic.Ability.ToShorthand(), true);
                }
            }
        }
    }
}
