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

        internal static IEnumerable<ICreatureAdjustor> Randomize(this IEnumerable<ICreatureAdjustor> adjustors, int delta)
        {
            var total = 0;

            var distanceLimit = delta.Abs();

            var choices = adjustors
                .Where(adjustor => delta > 0 ? (adjustor.EstimatedAdjustmentDistance > 0) : (adjustor.EstimatedAdjustmentDistance < 0))
                .Where(adjustor => adjustor.EstimatedAdjustmentDistance.Abs() <= (distanceLimit - total));

            var result = Enumerable
                .Range(1, distanceLimit)
                .Select(i => choices.PickRandomOrDefault())
                .TakeWhile(adjustor =>
                {
                    if (total == distanceLimit)
                    {
                        return false;
                    }

                    if (total + adjustor.EstimatedAdjustmentDistance.Abs() <= distanceLimit)
                    {
                        total += adjustor.EstimatedAdjustmentDistance.Abs();

                        return true;
                    }
                    else
                    {
                        return false;
                    }
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

            var array = adjustors.ToArray();

            var pick = Rng.Next(0, array.Length);

            return array[pick];
        }

        internal static T PickRandom<T>(this IEnumerable<T> adjustors)
        {
            var array = adjustors.ToArray();

            var pick = Rng.Next(0, array.Length);

            return array[pick];
        }
    }
}