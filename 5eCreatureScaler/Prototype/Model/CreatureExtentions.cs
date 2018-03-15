using CreatureScaler.Models;
using Newtonsoft.Json;
using System;

namespace CreatureScaler.Prototype.Model
{
    public static class CreatureExtensions
    {
        public static bool Has(this string containerString, string containedString)
        {
            return containerString.IndexOf(containedString, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static Creature Clone(this Creature creature)
        {
            return JsonConvert.DeserializeObject<Creature>(JsonConvert.SerializeObject(creature));
        }

        public static AbilityScore Strength(this Creature creature) => creature.Statistics.ByAbility(Ability.Strength);
        public static AbilityScore Dexterity(this Creature creature) => creature.Statistics.ByAbility(Ability.Dexterity);
        public static AbilityScore Constitution(this Creature creature) => creature.Statistics.ByAbility(Ability.Constitution);
        public static AbilityScore Intelligence(this Creature creature) => creature.Statistics.ByAbility(Ability.Intelligence);
        public static AbilityScore Wisdom(this Creature creature) => creature.Statistics.ByAbility(Ability.Wisdom);
        public static AbilityScore Charisma(this Creature creature) => creature.Statistics.ByAbility(Ability.Charisma);

        public static int GetModifierOrZero(this Creature creature, Ability ability)
        {
            return creature.Statistics.ByAbility(ability)?.Modifier ?? 0;
        }

        public static int GetModifier(this Creature creature, string property)
        {
            switch (property.ToLower())
            {
                case "p":
                case "proficiency":
                    return creature.ProficiencyBonus;
                case "str":
                case "strength":
                    return creature.Strength().Modifier;
                case "dex":
                case "dexterity":
                    return creature.Dexterity().Modifier;
                case "con":
                case "constitution":
                    return creature.Constitution().Modifier;
                case "int":
                case "intelligence":
                    return creature.Intelligence().Modifier;
                case "wis":
                case "wisdom":
                    return creature.Wisdom().Modifier;
                case "cha":
                case "charisma":
                    return creature.Charisma().Modifier;
                default:
                    return 0;
            }
        }
    }
}
