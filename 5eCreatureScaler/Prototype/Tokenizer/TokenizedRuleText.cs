using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class TokenizedRuleText
    {
        private string name;
        private string ruleText;
        private Creature creature;

        public TokenizedRuleText(string name, string ruleText, Creature creature)
        {
            this.creature = creature;
            this.name = name;
            this.ruleText = ruleText;

            CandidateTokens = ExtractTokens(ruleText).ToList();
        }

        private static IEnumerable<ICandidateToken> ExtractTokens(string ruleText)
        {
            foreach (var rulePattern in rulePatterns)
            {
                var matches = Regex.Matches(ruleText, rulePattern.pattern);

                foreach (var match in matches.Cast<Match>().Distinct(new MatchComparer()))
                {
                    yield return rulePattern.tokenFactory(match.Value);
                }
            }
        }

        private class MatchComparer : IEqualityComparer<Match>
        {
            public bool Equals(Match x, Match y)
            {
                return object.Equals(x.Value, y.Value);
            }

            public int GetHashCode(Match obj)
            {
                return obj.Value.GetHashCode();
            }
        }

        private static IEnumerable<(string pattern, Func<string, ICandidateToken> tokenFactory)> rulePatterns = new(string pattern, Func<string, ICandidateToken> tokenFactory)[]
        {
            (AttackBonusCandidateToken.Pattern, t=> new CandidateToken<AttackBonusCandidateToken>(t)),
            (ReachCandidateToken.Pattern, t=> new CandidateToken<ReachCandidateToken>(t)),
            (DamageRollCandidateToken.Pattern, t=> new CandidateToken<DamageRollCandidateToken>(t)),
            (DCCandidateToken.Pattern, t=> new CandidateToken<DCCandidateToken>(t)),
            (AreaOrDistanceCandidateToken.Pattern, t=> new CandidateToken<AreaOrDistanceCandidateToken>(t)),
            (AreaCandidateToken.Pattern, t=> new CandidateToken<AreaCandidateToken>(t)),
            (DamageTypeCandidateToken.Pattern, t=> new CandidateToken<DamageTypeCandidateToken>(t)),
        };

        public IEnumerable<ICandidateToken> CandidateTokens { get; }

        public string Format()
        {
            var newText = this.ruleText;

            foreach (var token in CandidateTokens.Where(token => token.Accepted))
            {
                var tokenized = token.Format(creature);

                if (token.TokenText != tokenized)
                {
                    newText = newText.Replace(token.TokenText, token.Format(creature));
                }
            }

            return newText;
        }
    }
}
