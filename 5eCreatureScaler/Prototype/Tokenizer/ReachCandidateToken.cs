using CreatureScaler.Models;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class ReachCandidateToken : IToken
    {
        public static string Pattern => @"reach [0-9]+ ft";

        public string Format(string tokenText, Creature creature)
        {
            var value = Regex.Match(tokenText, @"[0-9]+").Value;

            return $"reach {{reach:{value}}} ft";
        }
    }
}
