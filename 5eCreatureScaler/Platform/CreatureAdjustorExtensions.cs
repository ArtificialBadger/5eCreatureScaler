using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreatureScaler.Platform
{
    internal static class CreatureAdjustorExtensions
    {
        internal static Random Rng { get; set; } = new Random();

        internal static int Abs(this int i)
        {
            return Math.Abs(i);
        }

        internal static void Adjust(this ICreatureAdjustor adjustor, Creature creature, bool up)
        {
            var action = up ? new Action<Creature>(adjustor.AdjustUp) : new Action<Creature>(adjustor.AdjustDown);

            action(creature);
        }

        internal static IEnumerable<ICreatureAdjustor> Randomize(this IEnumerable<ICreatureAdjustor> adjustors, uint delta)
        {
            uint total = 0;

            uint distanceLimit = delta;

            var choices = adjustors
                .Where(adjustor => delta > 0 ? (adjustor.EstimatedAdjustmentDistance > 0) : (adjustor.EstimatedAdjustmentDistance < 0))
                .Where(adjustor => adjustor.EstimatedAdjustmentDistance <= (distanceLimit - total));

            var result = Enumerable
                .Range(1, (int)distanceLimit)
                .Select(i => choices.PickRandomOrDefault())
                .TakeWhile(adjustor =>
                {
                    if (total == distanceLimit)
                    {
                        return false;
                    }

                    total += adjustor.EstimatedAdjustmentDistance;

                    return true;
                })
                .ToList();

            return result;
        }

        internal static IEnumerable<ICreatureAdjustor> Randomize(this IEnumerable<ICreatureAdjustor> adjustors)
        {
            var randomized = adjustors
                .OrderBy(adjustor => Rng.Next())
                .ToList();

            return randomized;
        }

        internal static T PickRandomOrDefault<T>(this IEnumerable<T> adjustors)
        {
            if (!adjustors.Any())
            {
                return default(T);
            }

            return adjustors.PickRandom();
        }

        internal static T PickRandom<T>(this IEnumerable<T> adjustors)
        {
            var array = adjustors.ToArray();

            var pick = Rng.Next(0, array.Length);

            return array[pick];
        }
    }
}