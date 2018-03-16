using CreatureScaler.Models;
using CreatureScaler.Rules;
using System;

namespace CreatureScaler.RuleTokens
{
    public class AreaToken : Token
    {
        public int Area { get; set; }

        public AreaToken(TokenContext context) : base(context)
        {
            Area = Convert.ToInt32(context.TokenValue);
        }

        public override string TokenText => Retokenize(Area.ToString());

        public override string Format(Creature creature) => Area.ToString();
    }
}
