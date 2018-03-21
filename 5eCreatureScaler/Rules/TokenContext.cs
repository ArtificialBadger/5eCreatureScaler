using System;
using System.Linq;

namespace CreatureScaler.Rules
{
    public sealed class TokenContext
    {
        public static TokenContext Create(string tokenString)
        {
            var split = tokenString.Trim('{', '}').Split(':');
            var head = split[0];
            var value = split[1];
            var groups = split.Length > 2
                ? split[2].Split(',').Select(i => Convert.ToInt32(i)).ToArray()
                : new int[] { 0 };

            return new TokenContext()
            {
                Head = head,
                TokenValue = value,
                Groups = groups,
                TokenText = tokenString,
            };
        }

        public string Head { get; set; } = string.Empty;
        public string TokenValue { get; set; } = string.Empty;
        public string TokenText { get; set; } = string.Empty;
        public string Before { get; set; } = string.Empty;
        public string After { get; set; } = string.Empty;
        public int Index { get; set; } = 0;
        public int[] Groups { get; set; } = new int[] { };
    }
}
