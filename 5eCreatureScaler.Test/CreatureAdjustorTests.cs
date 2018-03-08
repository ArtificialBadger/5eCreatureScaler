using CreatureScaler.Models;
using CreatureScaler.Platform;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace _5eCreatureScaler.Test
{
    [TestClass]
    public class CreatureAdjustorTests
    {
        internal class CreatureAdjustorMock : ICreatureAdjustor
        {
            public static ICreatureAdjustor Create(uint i)
            {
                return new CreatureAdjustorMock()
                {
                    EstimatedAdjustmentDistance = i
                };
            }

            public uint EstimatedAdjustmentDistance { get; set; }

            public void AdjustUp(Creature creature)
            {
            }

            public void AdjustDown(Creature creature)
            {
            }

            public bool Qualified(Creature creature)
            {
                return true;
            }
        }

        [TestMethod]
        public void PositiveSeriesSucceeds()
        {
            uint delta = 50;

            var randomized = Enumerable.Range(1, 40).Select(f => (uint)f).Select(CreatureAdjustorMock.Create).Randomize(delta);

            var actual = randomized.Sum(f => f.EstimatedAdjustmentDistance);

            var expected = delta;

            Assert.AreEqual(expected, actual);
        }
    }
}
