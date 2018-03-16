using CreatureScaler.Models;
using CreatureScaler.Rules;
using System;
using System.Linq;

namespace CreatureScaler.RuleTokens
{
    public class DamageTypeToken : Token
    {
        public DamageType DamageType { get; set; }

        public DamageTypeToken(TokenContext context) : base(context)
        {
            DamageType = Enum
                .GetValues(typeof(DamageType))
                .Cast<DamageType>()
                .FirstOrDefault(f => Enum.GetName(typeof(DamageType), f).ToLower() == context.TokenValue);
        }

        public override string TokenText => Retokenize(DamageType.ToString().ToLower());

        public override string Format(Creature creature)
        {
            return DamageType.ToString().ToLower();
        }
    }
}
