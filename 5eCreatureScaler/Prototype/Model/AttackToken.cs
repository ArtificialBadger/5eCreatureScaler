using CreatureScaler.Models;
using CreatureScaler.Platform;
using System.Linq;

namespace CreatureScaler.Prototype.Model
{
    public class AttackToken : Token
    {
        public AttackToken(TokenContext context) : base(context) { }

        public override int Attack(Creature creature)
        {
            return GetAttack(creature);
        }

        int GetAttack(Prototype.Model.Creature creature)
        {
            var values = Context.TokenValue.Split('+');

            var total = values.Sum(v => creature.GetModifier(v));

            return total;
        }

        public override string Format(Creature creature)
        {
            var total = GetAttack(creature);

            return $"+{total.ToString()}";
        }
    }
}
