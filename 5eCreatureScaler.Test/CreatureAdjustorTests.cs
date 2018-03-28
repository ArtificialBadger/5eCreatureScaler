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

            public AdjustmentAttribute AdjustmentAttribute => throw new System.NotImplementedException();

            public int EstimatedAdjustmentDistance { get; set; }

            public void Adjust(Creature creature)
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

            var randomized = Enumerable.Range(1, 40).Select(CreatureAdjustorMock.Create).Randomize(delta);

            var actual = randomized.Sum(f => f.EstimatedAdjustmentDistance);

            var expected = delta;

            Assert.AreEqual(expected, actual);
        }
    }
}
