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
            public static ICreatureAdjustor Create(int i)
            {
                return new CreatureAdjustorMock()
                {
                    EstimatedAdjustmentDistance = i
                };
            }

            public AdjustorType Type { get; set; }

            public int EstimatedAdjustmentDistance { get; set; }

            public void Adjust(Creature creature)
            {
            }
        }

        [TestMethod]
        public void PositiveSeriesSucceeds()
        {
            var delta = 50;

            var randomized = Enumerable.Range(-20, 40).Where(f => f != 0).Select(CreatureAdjustorMock.Create).Randomize(delta);

            var actual = randomized.Sum(f => f.EstimatedAdjustmentDistance);

            var expected = delta;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NegativeSeriesSucceeds()
        {
            var delta = -50;

            var randomized = Enumerable.Range(-20, 40).Where(f => f != 0).Select(CreatureAdjustorMock.Create).Randomize(delta);

            var actual = randomized.Sum(f => f.EstimatedAdjustmentDistance);

            var expected = delta;

            Assert.AreEqual(expected, actual);
        }
    }
}
