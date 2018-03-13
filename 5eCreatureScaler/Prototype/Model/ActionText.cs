using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Model
{
    public class ActionText
    {
        public string Name { get; }
        public string RuleText { get; }
        public IRuleToken[] Tokens { get; }
        private readonly Creature parent;

        public ActionText(string ruleName, string ruleText, Creature parent)
        {
            this.parent = parent;
            this.Name = ruleName;
            this.RuleText = ruleText;
            this.Tokens = Regex
                .Matches(ruleText, "{(.*?)}")
                .Cast<Match>()
                .Select(f => (rulesText: f.Value, split: f.Value.Trim('{', '}').Split(':')))
                .Select(f => (
                    rulesText: f.rulesText, 
                    head: f.split[0], 
                    value: f.split[1], 
                    groups: 
                        f.split.Length > 2 
                        ? f.split[2].Split(',').Select(i => Convert.ToInt32(i)).ToArray() 
                        : new int[] { 0 }))
                .Select(f => new TokenContext(f.rulesText, f.head, f.value, f.groups))
                .Select(context => tokenMakers[context.Head](context))
                .ToArray();
        }

        // all of these should be objects
        private static Dictionary<string, Func<TokenContext, IRuleToken>> tokenMakers = new Dictionary<string, Func<TokenContext, IRuleToken>>
        {
            {"atk", context => new AttackToken(context)},
            {"attack", context => new AttackToken(context)},
            {"reach", context => new ReachToken(context)},
            {"type", context => new DamageTypeToken(context)},
            {"t", context => new DamageTypeToken(context)},
            {"damage", context => new DamageToken(context)},
            {"dmg", context => new DamageToken(context)},
            {"area", context => new AreaToken(context)},
            {"distance", context => new DistanceToken(context)},
            {"dc", context => new DifficultyClassToken(context)},
        };

        public string Format()
        {
            var newText = RuleText;

            foreach (var token in Tokens)
            {
                newText = newText.Replace(token.Context.TokenText, token.Format(parent));
            }

            return newText;
        }

        public double AverageAttack(Creature creature) => Tokens.PositiveSumOrZero(token => token.Attack(creature));
        public double AverageDamage(Creature creature) => Tokens.PositiveSumOrZero(token => token.Damage(creature));
        public double AverageDifficultyClass(Creature creature) => Tokens.PositiveSumOrZero(token => token.DifficultyClass(creature));
    }
}
