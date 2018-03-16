namespace CreatureScaler.Rules
{
    public sealed class TokenContext
    {
        public string Head { get; set; }
        public string TokenValue { get; set; }
        public string TokenText { get; set; }
        public string Before { get; set; }
        public string After { get; set; }
        public int Index { get; set; }
        public int[] Groups { get; set; }
    }
}
