using CreatureScaler.Models;

namespace CreatureScaler.Tokenization
{
    public class TokenizationContext
    {
        public TokenizationContext(IGrouper grouper, int index, string pattern, string before, string token, string after, Creature creature)
        {
            Index = index;
            Pattern = pattern;
            Grouper = grouper;
            Before = before;
            Token = token;
            After = after;
            Creature = creature;
        }

        public IGrouper Grouper { get; }

        public int Index { get; }

        public string Pattern { get; }

        public string Before { get; }

        public string Token { get; }

        public string After { get; }

        public Creature Creature { get; }

        public void Deconstruct(out string before, out string token, out string after, out Creature creature)
        {
            before = Before;
            token = Token;
            after = After;
            creature = Creature;
        }
    }
}
