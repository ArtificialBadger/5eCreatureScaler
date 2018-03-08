using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Tokenizer
{
    public sealed class CandidateToken<T> : ICandidateToken
        where T : IToken, new()
    {
        public CandidateToken(string tokenText)
        {
            this.TokenText = tokenText;
        }

        public T Token { get; } = new T();
        public string TokenText { get; }
        public bool Accepted { get; private set; } = false;
        public void Accept() => Accepted = true;
        public string Format(Creature creature) => Token.Format(TokenText, creature);
        public void Unaccept() => Accepted = false;
    }
}
