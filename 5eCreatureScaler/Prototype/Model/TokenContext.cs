namespace CreatureScaler.Prototype.Model
{
    public class TokenContext
    {
        public string Head { get; set; }
        public string TokenValue { get; set; }
        public string TokenText { get; set; }

        public TokenContext(string tokenText, string head, string tokenValue)
        {
            this.TokenText = tokenText;
            this.Head = head;
            this.TokenValue = tokenValue;
        }
    }
}
