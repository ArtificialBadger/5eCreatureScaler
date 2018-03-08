using CreatureScaler.Models;
using CreatureScaler.Platform;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public static class Dnd5ECalculations
    {
        public static string FindModString(this Creature creature, string tokenText)
        {
            var output = creature.FindMod(tokenText);

            var proficiencyString = output.proficient ? "+p" : string.Empty;

            return string.IsNullOrWhiteSpace(output.abilityScoreName.ToString()) ? default(string) : $"{output.abilityScoreName.ToString()}{proficiencyString}";
        }

        public static (string abilityScoreName, bool proficient) FindMod(this Creature creature, string tokenText)
        {
            var bonus = Convert.ToInt32(Regex.Match(tokenText, @"[0-9]+").Value);
            var abilityScore = default(string);
            var proficient = false;

            if (bonus >= creature.ProficiencyBonus + creature.Statistics.Select(a => a.Modifier).Min())
            {
                var bonusWithoutProficiency = bonus - creature.ProficiencyBonus;

                abilityScore =
                creature.Strength().Modifier >= creature.Dexterity().Modifier && creature.Strength().Modifier == bonusWithoutProficiency
                ?
                "str"
                :
                creature.Dexterity().Modifier == bonusWithoutProficiency
                ? "dex"
                :
                string.Empty;
            }

            if (abilityScore == default(string))
            {
                abilityScore =
                creature.Strength().Modifier >= creature.Dexterity().Modifier && creature.Strength().Modifier == bonus
                ?
                "str"
                :
                creature.Dexterity().Modifier == bonus
                ? "dex"
                :
                string.Empty;
            }
            else
            {
                proficient = true;
            }

            return (abilityScore, proficient);
        }
    }
}
