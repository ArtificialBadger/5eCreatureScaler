using CreatureScaler.Models;
using CreatureScaler.Platform;
using CreatureScaler.TokeizationSuggestions;
using CreatureScaler.Tokenization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Test.TokenizationTests
{
    [TestClass]
    public class GeneralTokenizationTests
    {

        private Creature bulette = new Creature()
        {
            Statistics = AbilityScore.CreateStandard(19, 11, 21, 2, 19, 5),
            ProficiencyBonus = 3,
            Actions = new List<Action>
            {
                Action.Create("Bite", @"Melee Weapon Attack: +7 to hit, reach 5 ft, one target. Hit: 30 (4d12 + 4) piercing damage."),
                Action.Create("Deadly Leap", @"If the bulette jumps at least 15 feet as part of its movement, it can then use this action to land on its feet in a space that contains one or more other creatures. Each of those creatures must succeed on a DC 16 Strength or Dexterity saving throw (target's choice) or be knocked prone and take 14 (3d6 + 4) bludgeoning damage plus 14 (3d6 + 4) slashing damage. On a successful save, the creature takes only half the damage, isn't knocked prone, and is pushed 5 feet out of the bulette's space into an unoccupied space of the creature's choice. If no unoccupied space is within range, the creature instead falls prone in the bulette's space."),
            },
        };

        private Creature azer = new Creature()
        {
            Statistics = AbilityScore.CreateStandard(17, 12, 15, 12, 13, 10),
            ProficiencyBonus = 2,
            Actions = new List<Action>
            {
                Action.Create("Warhammer",  @"Melee Weapon Attack: +5 to hit, reach 5 ft., one target. Hit: 7 (1d8 + 3) bludgeoning damage, or 8 (1d10 + 3) bludgeoning damage if used with two hands to make a melee attack, plus 3 (1d6) fire damage."),
                Action.Create("Heated Body",  @"A creature that touches the azer or hits it with a melee attack while within 5 feet of it takes 5(1d10) fire damage."),
                Action.Create("Heated Weapons", @"When the azer hits with a metal melee weapon, it deals an extra 3(1d6) fire damage(included in the attack)."),
                Action.Create("Illumination", @"The azer sheds bright light in a 10 - foot radius and dim light for an additional 10 feet."),
            }
        };

        private Tokenizer tokenizer = new Tokenizer(new ISuggestionProvider[]
        {
            new AreaOrDistanceSuggestion(),
            new AreaSuggestion(),
            new AttackBonusSuggestion(),
            new DamageRollSuggestion(),
            new DamageTypeSuggestion(),
            new DCSuggestion(),
            new ReachSuggestion(),
        });

        [TestMethod]
        public void TokenizationSuppliesCorrectNumberOfSuggestions()
        {
            var output = tokenizer.Tokenize(azer.Actions[0].Name, azer.Actions[0].RulesText.Text, azer);

            Assert.AreEqual(2, output.Suggestions[0].Choices.Count());
            Assert.AreEqual(1, output.Suggestions[1].Choices.Count());
            Assert.AreEqual(2, output.Suggestions[2].Choices.Count());
            Assert.AreEqual(1, output.Suggestions[3].Choices.Count());
            Assert.AreEqual(4, output.Suggestions[4].Choices.Count());
            Assert.AreEqual(1, output.Suggestions[5].Choices.Count());
            Assert.AreEqual(2, output.Suggestions[6].Choices.Count());
            Assert.AreEqual(1, output.Suggestions[7].Choices.Count());
        }

        [TestMethod]
        public void TakingFirstSuggestionYieldsMostLikelyRulesText()
        {
            var output = tokenizer.Tokenize(azer.Actions[0].Name, azer.Actions[0].RulesText.Text, azer);

            foreach (var suggestion in output.Suggestions)
            {
                suggestion.Choices.First().Choose();
            }

            var rulesText = output.Format();

            var expected = @"Melee Weapon Attack: {attack:str+p} to hit, reach {reach:5} ft., one target. Hit: {dmg:1d8+str} {type:bludgeoning} damage, or {dmg:1d10+str:1} {type:bludgeoning} damage if used with two hands to make a melee attack, plus {dmg:1d6:0,1} {type:fire} damage.";

            Assert.AreEqual(expected, rulesText);
        }

        [TestMethod]
        public void SkippingFirstSuggestionYieldsMostLikelyRulesText()
        {
            var output = tokenizer.Tokenize(azer.Actions[0].Name, azer.Actions[0].RulesText.Text, azer);

            output.Suggestions.First().Reject();

            foreach (var suggestion in output.Suggestions.Skip(1))
            {
                suggestion.ChooseFirst();
            }

            var rulesText = output.Format();

            var expected = @"Melee Weapon Attack: +5 to hit, reach {reach:5} ft., one target. Hit: {dmg:1d8+str} {type:bludgeoning} damage, or {dmg:1d10+str:1} {type:bludgeoning} damage if used with two hands to make a melee attack, plus {dmg:1d6:0,1} {type:fire} damage.";

            Assert.AreEqual(expected, rulesText);
        }

        [TestMethod]
        public void RejectAllYieldsOriginalText()
        {
            var output = tokenizer.Tokenize(azer.Actions[0].Name, azer.Actions[0].RulesText.Text, azer);
            
            foreach (var suggestion in output.Suggestions.Skip(1))
            {
                suggestion.Reject();
            }

            var rulesText = output.Format();

            var expected = @"Melee Weapon Attack: +5 to hit, reach 5 ft., one target. Hit: 7 (1d8 + 3) bludgeoning damage, or 8 (1d10 + 3) bludgeoning damage if used with two hands to make a melee attack, plus 3 (1d6) fire damage.";

            Assert.AreEqual(expected, rulesText);
        }
    }
}
