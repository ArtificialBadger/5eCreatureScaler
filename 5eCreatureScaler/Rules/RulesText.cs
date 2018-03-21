using CreatureScaler.Models;
using CreatureScaler.RuleTokens;
using CreatureScaler.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace CreatureScaler.Rules
{
    public sealed class RulesText
    {
        public static RulesText CreateMeleeAttack(int reach, Die damageDie, int damageDieCount, Creature creature, Ability attackAbilltyStat, DamageType damageType)
        {
            return new RulesText() { Text = "{attack:str+p} to hit, reach {reach:" + reach + "} ft., one target. Hit: {damage:" + damageDieCount + damageDie.GetDisplayName() + "+" + creature.Statistics.First(a => a.Ability == attackAbilltyStat).Modifier + "} {type:" + damageType + "} damage." };
        }

        // TODO CreateRangedAttack

        private string rulesText;

        public static RulesText Create(string rulesText)
        {
            return new RulesText()
            {
                Text = rulesText,
            };
        }

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
        
        public string Text
        {
            get
            {
                var reconstitutedString = (Tokens.FirstOrDefault()?.Context.Before ?? String.Empty)
                    + Tokens.Select(token => token.TokenText + token.Context.After);

                return reconstitutedString;
            }
            set
            {
                rulesText = value;
                Tokens = value
                    .SplitIncludingValuesBetween(new[] { "{(.*?)}" })
                    .Select(f => (record: f, split: f.token.Trim('{', '}').Split(':')))
                    .Select(f => (
                        record: f.record,
                        head: f.split[0],
                        value: f.split[1],
                        groups:
                            f.split.Length > 2
                            ? f.split[2].Split(',').Select(i => Convert.ToInt32(i)).ToArray()
                            // default non-grouped tokens to group 0
                            : new int[] { 0 }))
                    .Select((f, i) =>
                        new TokenContext()
                        {
                            TokenText = f.record.token,
                            TokenValue = f.value,
                            Groups = f.groups,
                            After = f.record.after,
                            Before = f.record.before,
                            Head = f.head,
                            Index = i,
                        })
                    .Select(context => tokenMakers[context.Head](context))
                    .ToArray();
            }
        }

        [IgnoreDataMember]
        public IRuleToken[] Tokens { get; private set; } = new IRuleToken[] { };

        public string Format(Creature creature)
        {
            var newText = Text;

            foreach (var token in Tokens)
            {
                newText = newText.Replace(token.Context.TokenText, token.Format(creature));
            }

            return newText;
        }

        public double AverageAttack(Creature creature) => Tokens.PositiveSumOrZero((Func<IRuleToken, int>)(token => token.DifficultyClass((Creature)creature)));

        public double AverageDamage(Creature creature) => Tokens.PositiveSumOrZero(token => token.Damage(creature));

        public double AverageDifficultyClass(Creature creature) => Tokens.PositiveSumOrZero((Func<IRuleToken, int>)(token => token.DifficultyClass((Creature)creature)));
    }
}
