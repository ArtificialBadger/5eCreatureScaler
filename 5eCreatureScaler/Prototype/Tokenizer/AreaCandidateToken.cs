using CreatureScaler.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AreaCandidateToken : IToken
    {
        public static string Pattern => @"[0-9]+ ?- ?foot";

        public string Format(string tokenText, Creature creature)
        {
            var value = Regex.Match(tokenText, @"[0-9]+").Value;

            var remainder = Regex.Split(tokenText, @"[0-9]+").Last();

            return $"{{area:{value}}}{remainder}";
        }
    }
}
