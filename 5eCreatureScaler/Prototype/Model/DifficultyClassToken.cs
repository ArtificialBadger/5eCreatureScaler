using CreatureScaler.Models;
using CreatureScaler.Platform;
using System.Linq;

namespace CreatureScaler.Prototype.Model
{
    public class DifficultyClassToken : Token
    {
        public DifficultyClassToken(TokenContext context) : base(context) { }

        public override string Format(Creature creature)
        {
            var dc = GetDC(creature);

            return $"DC {dc.ToString()}";
        }

        int GetDC(Creature creature)
        {
            var values = Context.TokenValue.Split('+');

            var total = 8 + values.Sum(v => creature.GetModifier(v));

            return total;
        }

        public override int DifficultyClass(Creature creature)
        {
            return GetDC(creature);
        }
    }
}
