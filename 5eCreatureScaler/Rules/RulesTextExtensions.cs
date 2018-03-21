using CreatureScaler.RuleTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Rules
{
    public static class RulesTextExtensions
    {
        public static bool IsAttack(this RulesText rulesText) => rulesText.Tokens.Any(token => token is AttackToken);
        public static bool HasSpecialEffect(this RulesText rulesText) => rulesText.Tokens.Any(token => token is DifficultyClassToken);
        public static bool DealsDamage(this RulesText rulesText) => rulesText.Tokens.Any(token => token is DamageToken);
        public static IEnumerable<T> Get<T>(this RulesText rulesText) => rulesText.Tokens.Where(token => token is T).Cast<T>();
        public static IEnumerable<T> Get<T>(this RulesText rulesText, Func<T, bool> filter) => rulesText.Tokens.Where(token => token is T).Cast<T>().Where(filter);
    }
}
