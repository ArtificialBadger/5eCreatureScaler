using System;
using System.Linq;
using CreatureScaler.Models;

namespace CreatureScaler.Rules
{
    public abstract class Token : IRuleToken
    {
        public TokenContext Context { get; }

        public string Type => Context.Head;

        public abstract string TokenText { get; }

        public Token(TokenContext context)
        {
            this.Context = context;
        }

        public abstract string Format(Creature creature);

        protected string Retokenize(string tokenValue)
        {
            return $"{{{Context.Head}:{tokenValue}{GetGroupString()}}}";
        }

        private string GetGroupString()
        {
            if (new [] { 0 }.SequenceEqual(Context.Groups))
            {
                return string.Empty;
            }
            else
            {
                return $":{Context.Groups.Stitch(",")}";
            }
        }
    }
}
