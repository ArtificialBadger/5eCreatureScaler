﻿using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AttackBonusSuggestion : SuggestionProvider
    {
        public override string Pattern => @"\+[0-9]+ to hit";

        protected override IEnumerable<Suggestion> SuggestReplacements(Match match, Creature creature)
        {
            var tokenText = match.Value;
            var bonus = Convert.ToInt32(Regex.Match(tokenText, @"[0-9]+"));

            var output = creature.FindMatchingStatisticsWithProficiency(bonus);

            return output
                .Select(o => (combo: o, modString: o.ToModString()))
                .Where(o => !string.IsNullOrWhiteSpace(o.modString))
                .Select(o => (combo: o.combo, value: o.modString == default(string) ? tokenText : $"{{attack:{o.modString}}} to hit"))
                .Select(o => new Suggestion(match.Index, tokenText, Pattern, o.value))
                .Concat(new[] { new Suggestion(match.Index, tokenText, Pattern, $"{{attack:{bonus}}} to hit") });
        }
    }
}