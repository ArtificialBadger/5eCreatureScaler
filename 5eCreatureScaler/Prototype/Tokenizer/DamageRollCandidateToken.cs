using CreatureScaler.Models;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DamageRollCandidateToken : IToken
    {
        public static string Pattern => @"[0-9]+ ?\([0-9]+d[0-9]+( ?\+ ?[0-9]+)?\)";

        public string Format(string tokenText, Creature creature)
        {
            var matches = Regex.Matches(tokenText, @"[0-9]+").Cast<Match>().Select(f => f.Value).Skip(1);

            var dieCount = matches.First();
            var dieSize = matches.Skip(1).First();
            var originalBonus = matches.Skip(2).FirstOrDefault();
            var bonus = originalBonus;

            if (bonus != default(string))
            {
                bonus = creature.Statistics.FirstOrDefault(a => a.Modifier.ToString() == bonus)?.Ability.ToString().ToLower() ?? default(string);
            }

            if (bonus != default(string))
            {
                bonus = "+" + bonus.ToLower();
            }
            else if (!string.IsNullOrWhiteSpace(originalBonus))
            {
                bonus = "+" + originalBonus;
            }

            var output = $"{{dmg:{dieCount}d{dieSize}{bonus}}}";

            return output;
        }
    }
}
