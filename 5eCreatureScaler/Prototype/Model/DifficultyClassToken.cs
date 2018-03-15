using CreatureScaler.Models;
using System;

namespace CreatureScaler.Prototype.Model
{
    public sealed class DifficultyClassToken : Token
    {
        public Ability Ability { get; }
        public bool Proficient { get; set; }

        public DifficultyClassToken(TokenContext context) : base(context)
        {
            var values = context.TokenValue.Split('+');

            this.Ability = values[0].ToAbility();

            this.Proficient = values.Length > 1;

            if (this.Proficient)
            {
                if (values[1] != "p")
                {
                    throw new InvalidOperationException($"'{values[1]}' is an invalid part of token '{Context.TokenValue}'.");
                }
            }
        }

        public override int DifficultyClass(Creature creature)
        {
            return GetDifficultyClass(creature);
        }

        int GetDifficultyClass(Creature creature)
        {
            var total = 8 + creature.GetModifierOrZero(Ability) + (Proficient ? creature.ProficiencyBonus : 0);

            return total;
        }

        string ProficiencyString
        {
            get
            {
                return Proficient ? "+p" : string.Empty;
            }
        }

        public override string TokenText => Retokenize($"{Ability.ToShorthand()}{ProficiencyString}");

        public override string Format(Creature creature)
        {
            var total = GetDifficultyClass(creature);

            return $"+{total.ToString()}";
        }
    }
}
