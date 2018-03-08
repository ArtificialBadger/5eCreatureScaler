using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DCCandidateToken : IToken
    {
        public static string Pattern => @"DC [0-9]+";

        public string Format(string tokenText, Creature creature)
        {
            var output = creature.FindModString(tokenText);

            return output == default(string) ? default(string) : $"{{dc:{output}}}";
        }
    }
}
