using CreatureScaler.RuleTokens;
using System.Linq;

namespace CreatureScaler.Rules
{
    public static class RulesTextExtensions
    {
        public static bool IsAttack(this RulesText rulesText) => rulesText.Tokens.Any(token => token is AttackToken);
    }
}
