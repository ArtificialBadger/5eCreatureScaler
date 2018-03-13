namespace CreatureScaler.Prototype.Model
{
    public sealed class TokenContext
    {
        public string Head { get; }
        public string TokenValue { get; }
        public int[] Groups { get; }
        public string TokenText { get; }

        public TokenContext(string token, string head, string tokenValue, int[] groups)
        {
            this.TokenText = token;
            this.Head = head;
            this.TokenValue = tokenValue;
            this.Groups = groups;
        }
    }
}
