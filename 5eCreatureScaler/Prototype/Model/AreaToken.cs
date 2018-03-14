using System;

namespace CreatureScaler.Prototype.Model
{
    public class AreaToken : Token
    {
        public int Area { get; set; }

        public AreaToken(TokenContext context) : base(context)
        {
            Area = Convert.ToInt32(context.TokenValue);
        }

        public override string TokenText => Retokenize(Area.ToString());
    }
}
