using CreatureScaler.Models;
using CreatureScaler.RuleTokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Rules
{
    public static class RulesTextExtensions
    {
        public static bool IsAttack(this RulesText rulesText) => rulesText.Get<AttackToken>().Any();
        public static bool HasSpecialEffect(this RulesText rulesText) => rulesText.Get<DifficultyClassToken>().Any();
        public static bool DealsDamage(this RulesText rulesText) => rulesText.Get<DamageToken>().Any();
        public static IEnumerable<T> Get<T>(this RulesText rulesText) => rulesText.Tokens.Where(token => token is T).Cast<T>();
        public static IEnumerable<IGrouping<int, T>> ByTokenGrouping<T>(this IEnumerable<T> tokens)
            where T : IRuleToken
            => tokens
            .SelectMany(token => token.Context.Groups.Select(group => (group: group, token: token)))
            .GroupBy(row => row.group, row => row.token);
        private static int CalculateMax<T>(this IEnumerable<IGrouping<int, T>> groupings, Func<T, int> calculator)
            where T : IRuleToken
            => groupings
            .MaxOrZero(group => group.PositiveSumOrZero(calculator));

        public static int MaximumAttackBonus(this RulesText rulesText, Creature creature)
            => rulesText
            .Get<AttackToken>()
            .ByTokenGrouping()
            .CalculateMax(token => token.CalculateAttack(creature));
        public static int MaximumDamagePerRound(this RulesText rulesText, Creature creature)
            => rulesText
            .Get<DamageToken>()
            .ByTokenGrouping()
            .CalculateMax(token => token.CalculateDamage(creature));
        public static int MaximumDifficultyClass(this RulesText rulesText, Creature creature)
            => rulesText
            .Get<DifficultyClassToken>()
            .ByTokenGrouping()
            .CalculateMax(token => token.CalculateDifficultyClass(creature));
    }
}
