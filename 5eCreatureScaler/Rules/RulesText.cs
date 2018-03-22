using CreatureScaler.Models;
using CreatureScaler.RuleTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Reflection;
using CreatureScaler.ViewModels;

namespace CreatureScaler.Rules
{
    public sealed class RulesText
    {
        #region static shit
        private static Dictionary<string, Func<TokenContext, IRuleToken>> tokenMakers = new Dictionary<string, Func<TokenContext, IRuleToken>>();
        private static void Add<T>(Func<TokenContext, T> creator)
            where T : IRuleToken
        {
            var heads = typeof(T).GetCustomAttributes<TokenHeadAttribute>().Select(t => t.Head);

            foreach (var head in heads)
            {
                tokenMakers.Add(head, c => creator(c));
            }
        }
        private static IRuleToken CreateToken(TokenContext context)
        {
            return tokenMakers[context.Head](context);
        }
        static RulesText()
        {
            Add(context => new AttackToken(context));
            Add(context => new ReachToken(context));
            Add(context => new DamageTypeToken(context));
            Add(context => new DamageToken(context));
            Add(context => new AreaToken(context));
            Add(context => new DistanceToken(context));
            Add(context => new DifficultyClassToken(context));
        }
        #endregion

        private string rulesText;
        private readonly Func<TokenContext, IRuleToken> ruleTokenFactory = CreateToken;

        public string Text
        {
            get
            {
                var reconstitutedString = Tokens.Any()
                    ? Tokens.First().Context.Before +
                        Tokens.Select(token => token.TokenText + token.Context.After).Stitch()
                    : rulesText;

                return reconstitutedString;
            }
            set
            {
                rulesText = value;
                Tokens = value
                    .SplitIncludingValuesBetween(new[] { "{(.*?)}" })

                    .Select((f, i) => TokenContext.Create(f.token)
                        .Act(t => t.After = f.after)
                        .Act(t => t.Before = f.before)
                        .Act(t => t.Index = i))

                    .Select(context => ruleTokenFactory(context))
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
    }
}
