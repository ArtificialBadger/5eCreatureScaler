using CreatureScaler.Models;
using System;

namespace CreatureScaler.Prototype.Model
{
    public class DamageToken : Token
    {
        //public int Count { get; set; }
        //public Die Size { get; set; }
        //public Ability ModifiedBy { get; set; }
        //public int FlatBonus { get; set; }

        public DamageToken(TokenContext context) : base(context)
        {
        }

        (int total, int count, int size, int modifier) StructureDieRoll(Prototype.Model.Creature creature)
        {
            var split = Context.TokenValue.Split('+');

            var dieRoll = split[0].Split('d');

            var dieCount = dieRoll[0];
            var dieSize = dieRoll[1];
            
            var modifier = 0;

            if (split.Length > 1)
            {
                modifier = creature.GetModifier(split[1]);

                if (modifier == 0)
                {
                    modifier = Convert.ToInt32(split[1]);
                }
            }

            var count = Convert.ToInt32(dieCount);
            var size = Convert.ToInt32(dieSize);

            var averageDamagePerDie = ((size / 2d) + 0.5);

            var damageTotal = Math.Floor(count * averageDamagePerDie) + modifier;

            return (total: (int)damageTotal, count: count, size: size, modifier: modifier);
        }

        public override string Format(Creature creature)
        {
            var dieRoll = StructureDieRoll(creature);

            var modifierText = dieRoll.modifier > 0 ? $" + {dieRoll.modifier.ToString()}" : "";

            var replacementText = $"{dieRoll.total.ToString()} ({dieRoll.count.ToString()}d{dieRoll.size.ToString()}{modifierText})";

            return replacementText;
        }

        public override int Damage(Creature creature)
        {
            return StructureDieRoll(creature).total;
        }
    }
}
