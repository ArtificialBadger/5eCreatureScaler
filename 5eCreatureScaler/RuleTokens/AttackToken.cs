using CreatureScaler.Models;
using CreatureScaler.Rules;
using System;

namespace CreatureScaler.RuleTokens
{
    public sealed class AttackToken : Token
    {
        public Ability Ability { get; }
        public bool Proficient { get; set; }

        public AttackToken(TokenContext context) : base(context)
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
        
        public override int Attack(Creature creature)
        {
            return GetAttack(creature);
        }

        int GetAttack(Creature creature)
        {
            var total = creature.GetModifierOrZero(Ability) + (Proficient ? creature.ProficiencyBonus : 0);

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
            var total = GetAttack(creature);

            return $"+{total.ToString()}";
        }
    }
}
