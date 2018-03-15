using System;

namespace CreatureScaler.Prototype.Model
{
    public class DistanceToken : Token
    {
        public int Distance { get; set; }

        public DistanceToken(TokenContext context) : base(context)
        {
            Distance = Convert.ToInt32(context.TokenValue);
        }

        public override string TokenText => Retokenize(Distance.ToString());

        public override string Format(Creature creature) => Distance.ToString();
    }
}
