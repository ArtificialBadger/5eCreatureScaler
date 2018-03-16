using CreatureScaler.Models;
using CreatureScaler.Rules;
using System;

namespace CreatureScaler.RuleTokens
{
    public class ReachToken : Token
    {
        public int Reach { get; set; }

        public ReachToken(TokenContext context) : base(context)
        {
            Reach = Convert.ToInt32(context.TokenValue);
        }

        public override string TokenText => Retokenize(Reach.ToString());
        public override string Format(Creature creature) => Reach.ToString();
    }
}
