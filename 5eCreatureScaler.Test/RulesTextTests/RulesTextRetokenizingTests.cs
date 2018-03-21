using CreatureScaler.Models;
using CreatureScaler.Rules;
using CreatureScaler.RuleTokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CreatureScaler.Test.RulesTextTests
{
    [TestClass]
    public class RulesTextRetokenizingTests
    {
        [TestMethod]
        public void AreaTokenCorrectlyRetokenizes()
        {
            var token = new AreaToken(TokenContext.Create(@"{area:5}"));

            token.Area = 6;

            var actual = token.TokenText;
            var expected = @"{area:6}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AttackTokenCorrectlyRetokenizes()
        {
            var token = new AttackToken(TokenContext.Create(@"{attack:str+p}"));

            token.Ability = Ability.Wisdom;
            token.Proficient = false;

            var actual = token.TokenText;
            var expected = @"{attack:wis}";

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void DamageTokenCorrectlyRetokenizes()
        {
            var token = new DamageToken(TokenContext.Create(@"{damage:1d8+str:1,2}"));

            token.Count = 2;
            token.Size = Die.D10;
            token.ModifiedBy = Ability.Intelligence;

            var actual = token.TokenText;
            var expected = @"{damage:2d10+int:1,2}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DamageTypeTokenCorrectlyRetokenizes()
        {
            var token = new DamageTypeToken(TokenContext.Create(@"{type:bludgeoning}"));

            token.DamageType = DamageType.Fire;

            var actual = token.TokenText;
            var expected = @"{type:fire}";

            Assert.AreEqual(expected, actual);
        }

        public void DCTokenCorrectlyRetokenizes()
        {
            var token = new DifficultyClassToken(TokenContext.Create(@"{DC:wisdom+p}"));

            token.Ability = Ability.Charisma;
            token.Proficient = true;

            var actual = token.TokenText;
            var expected = @"{dc:cha+p}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DistanceTokenCorrectlyRetokenizes()
        {
            var token = new DistanceToken(TokenContext.Create(@"{distance:5}"));

            token.Distance = 6;

            var actual = token.TokenText;
            var expected = @"{distance:6}";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ReachTokenCorrectlyRetokenizes()
        {
            var token = new ReachToken(TokenContext.Create(@"{reach:5}"));

            token.Reach = 6;

            var actual = token.TokenText;
            var expected = @"{reach:6}";

            Assert.AreEqual(expected, actual);
        }
    }
}
