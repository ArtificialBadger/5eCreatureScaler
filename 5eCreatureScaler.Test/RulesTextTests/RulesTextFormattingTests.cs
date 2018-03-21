using CreatureScaler.Models;
using CreatureScaler.Rules;
using CreatureScaler.RuleTokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CreatureScaler.Test.RulesTextTests
{
    [TestClass]
    public class RulesTextFormattingTests
    {
        private Creature azer = new Creature()
        {
            Statistics = AbilityScore.CreateStandard(16, 14, 15, 12, 10, 12),
            ProficiencyBonus = 2,
        };

        [TestMethod]
        public void AreaTokenCorrectlyFormatted()
        {
            var token = new AreaToken(TokenContext.Create(@"{area:5}"));

            var actual = token.Format(azer);
            var expected = @"5";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AttackTokenCorrectlyFormatted()
        {
            var token = new AttackToken(TokenContext.Create(@"{attack:str+p}"));

            var actual = token.Format(azer);
            var expected = @"+5";

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void DamageTokenCorrectlyFormatted()
        {
            var token = new DamageToken(TokenContext.Create(@"{damage:1d8+str:1,2}"));

            var actual = token.Format(azer);
            var expected = @"7 (1d8 + 3)";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DamageTypeTokenCorrectlyFormatted()
        {
            var token = new DamageTypeToken(TokenContext.Create(@"{type:bludgeoning}"));

            var actual = token.Format(azer);
            var expected = @"bludgeoning";

            Assert.AreEqual(expected, actual);
        }

        public void DCTokenCorrectlyFormatted()
        {
            var token = new DifficultyClassToken(TokenContext.Create(@"{DC:wisdom+p}"));

            var actual = token.Format(azer);
            var expected = @"DC 10";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DistanceTokenCorrectlyFormatted()
        {
            var token = new DistanceToken(TokenContext.Create(@"{distance:5}"));

            var actual = token.Format(azer);
            var expected = @"5";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReachTokenCorrectlyFormatted()
        {
            var token = new ReachToken(TokenContext.Create(@"{reach:5}"));

            var actual = token.Format(azer);
            var expected = @"5";

            Assert.AreEqual(expected, actual);
        }
    }
}
