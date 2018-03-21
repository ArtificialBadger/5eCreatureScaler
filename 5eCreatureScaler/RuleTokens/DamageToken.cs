using CreatureScaler.Models;
using CreatureScaler.Rules;
using System;

namespace CreatureScaler.RuleTokens
{
    public class DamageToken : Token
    {
        public int Count { get; set; }
        public Die Size { get; set; }
        public Ability ModifiedBy { get; set; } = Ability.None;
        public int FlatBonus { get; set; } = 0;

        public DamageToken(TokenContext context) : base(context)
        {
            var split = Context.TokenValue.Split('+');

            var dieRoll = split[0].Split('d');

            var dieCount = dieRoll[0];
            var dieSize = dieRoll[1];
            
            Count = Convert.ToInt32(dieCount);
            Size = dieSize.ToDie();
            
            if (split.Length > 1)
            {
                var modifier = split[1];

                var modifierValue = default(int);
                if (Int32.TryParse(modifier, out modifierValue))
                {
                    FlatBonus = modifierValue;
                }
                else
                {
                    ModifiedBy = modifier.ToAbility();
                }
            }
        }

        string ModifierString
        {
            get
            {
                if (ModifiedBy != Ability.None)
                {
                    return $"+{ModifiedBy.ToShorthand()}";
                }
                else if (FlatBonus > 0)
                {
                    return $"+{FlatBonus.ToString()}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public override string TokenText => Retokenize($"{Count.ToString()}d{((int)Size).ToString()}{ModifierString}");

        (int total, int modifier) StructureDieRoll(Creature creature)
        {
            var averageDamagePerDie = ((Size.ToAverageValue() / 2d));

            var modifier = FlatBonus + creature.GetModifierOrZero(ModifiedBy);

            var damageTotal = Math.Floor(Count * averageDamagePerDie) + modifier;

            return (total: (int)damageTotal, modifier: modifier);
        }

        public override string Format(Creature creature)
        {
            var dieRoll = StructureDieRoll(creature);

            var modifierText = dieRoll.modifier > 0 ? $" + {dieRoll.modifier.ToString()}" : "";

            var replacementText = $"{dieRoll.total.ToString()} ({Count.ToString()}d{((int)Size).ToString()}{modifierText})";

            return replacementText;
        }

        public override int Damage(Creature creature)
        {
            return StructureDieRoll(creature).total;
        }
    }
}
