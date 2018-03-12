using System;

namespace CreatureScaler.Prototype.Tokenizer
{
    public sealed class Suggestion
    {
        public Suggestion(int index, string token, string pattern, string replacement)
        {
            Index = index;
            Token = token;
            Pattern = pattern;
            Replacement = replacement;
        }

        public int Index { get; }
        public string Token { get; }
        public string Pattern { get; }
        public string Replacement { get; }
    }
}
