using CreatureScaler.Models;
using CreatureScaler.Rules;
using CreatureScaler.RuleTokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CreatureScaler.Test.RulesTextTests
{
    [TestClass]
    public class RulesTextExtractionTests
    {
        [TestMethod]
        public void AreaTokenCorrectlyExtractsInformation()
        {
            var token = new AreaToken(TokenContext.Create(@"{area:5}"));

            Assert.AreEqual(5, token.Area);
            Assert.IsTrue(new int[] { 0 }.SequenceEqual(token.Context.Groups));
        }

        [TestMethod]
        public void AttackTokenCorrectlyExtractsInformation()
        {
            var token = new AttackToken(TokenContext.Create(@"{attack:str+p}"));

            Assert.AreEqual(Ability.Strength, token.Ability);
            Assert.IsTrue(token.Proficient);
            Assert.IsTrue(new int[] { 0 }.SequenceEqual(token.Context.Groups));
        }
        
        [TestMethod]
        public void DamageTokenCorrectlyExtractsInformation()
        {
            var token = new DamageToken(TokenContext.Create(@"{damage:1d8+str:1,2}"));

            Assert.AreEqual(1, token.Count);
            Assert.AreEqual(Die.D8, token.Size);
            Assert.AreEqual(Ability.Strength, token.ModifiedBy);
            Assert.AreEqual(0, token.FlatBonus);
            Assert.IsTrue(new int[] { 1, 2 }.SequenceEqual(token.Context.Groups));
        }

        [TestMethod]
        public void DamageTypeTokenCorrectlyExtractsInformation()
        {
            var token = new DamageTypeToken(TokenContext.Create(@"{type:bludgeoning}"));

            Assert.AreEqual(DamageType.Bludgeoning, token.DamageType);
            Assert.IsTrue(new int[] { 0 }.SequenceEqual(token.Context.Groups));
        }

        public void DCTokenCorrectlyExtractsInformation()
        {
            var token = new DifficultyClassToken(TokenContext.Create(@"{DC:wisdom+p}"));

            Assert.AreEqual(Ability.Wisdom, token.Ability);
            Assert.IsTrue(token.Proficient);
            Assert.IsTrue(new int[] { 0 }.SequenceEqual(token.Context.Groups));
        }

        [TestMethod]
        public void DistanceTokenCorrectlyExtractsInformation()
        {
            var token = new DistanceToken(TokenContext.Create(@"{distance:5}"));

            Assert.AreEqual(5, token.Distance);
            Assert.IsTrue(new int[] { 0 }.SequenceEqual(token.Context.Groups));
        }

        [TestMethod]
        public void ReachTokenCorrectlyExtractsInformation()
        {
            var token = new ReachToken(TokenContext.Create(@"{reach:5}"));

            Assert.AreEqual(5, token.Reach);
            Assert.IsTrue(new int[] { 0 }.SequenceEqual(token.Context.Groups));
        }
    }
}
