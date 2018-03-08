using CreatureScaler.Models;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AreaOrDistanceCandidateToken : IToken
    {
        // ask if area or distance

        public static string Pattern => @"[0-9]+ feet";

        public string Format(string tokenText, Creature creature)
        {
            var value = Regex.Match(tokenText, @"[0-9]+").Value;

            return $"{{area:{value}}} feet";
        }
    }
}
