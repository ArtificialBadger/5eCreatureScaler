using System;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public static class SkillExtensions
    {
        private static Dictionary<Skill, Ability> SkillMap = new Dictionary<Skill, Ability>
            {
                {     Skill.Athletics, Ability.Strength},
                {     Skill.Acrobatics, Ability.Dexterity},
                {     Skill.SleightofHand, Ability.Dexterity },
                {     Skill.Stealth, Ability.Dexterity },
                {     Skill.Arcana, Ability.Intelligence },
                {     Skill.History, Ability.Intelligence },
                {     Skill.Investigation, Ability.Intelligence },
                {     Skill.Nature, Ability.Intelligence },
                {     Skill.Religion, Ability.Intelligence },
                {     Skill.AnimalHandling, Ability.Wisdom },
                {     Skill.Insight, Ability.Wisdom },
                {     Skill.Medicine, Ability.Wisdom },
                {     Skill.Perception, Ability.Wisdom },
                {     Skill.Survival, Ability.Wisdom },
                {     Skill.Deception, Ability.Charisma },
                {     Skill.Intimidation, Ability.Charisma },
                {     Skill.Performance, Ability.Charisma },
                {     Skill.Persuasion, Ability.Charisma },

            };

        public static Ability ToAbility(this Skill skill)
        {
            return SkillMap[skill];
        }
    }

    public enum Skill
    {
        Athletics,
        Acrobatics,
        SleightofHand,
        Stealth,
        Arcana,
        History,
        Investigation,
        Nature,
        Religion,
        AnimalHandling,
        Insight,
        Medicine,
        Perception,
        Survival,
        Deception,
        Intimidation,
        Performance,
        Persuasion,
    }
}