namespace CreatureScaler.Tokenization
{
    public sealed class Suggestion
    {
        public Suggestion(string token, string replacement)
        {
            Token = token;
            Replacement = replacement;
        }
        
        public string Token { get; }
        public string Replacement { get; }
    }
}
