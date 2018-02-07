using System;
using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public class Health
    {
        private static int CalculateMaximumHitPoints(Size size, List<AbilityScore> statistics, int hitDieCount)
        {
            return (int)(
                Math.Floor(hitDieCount * size.ToHitDie().ToHitPointPerLevel())
                +
                hitDieCount * statistics.ByAbility(Ability.Constitution)?.Modifier ?? 0
                );
        }

        public int HitPointMaximum { get; set; }
        public int HitDieCount { get; set; }
        public Die HitDieSize { get; set; }

        public static Health Create(Size size, int hitDieCount, List<AbilityScore> abilityScores)
        {
            return new Health()
            {
                HitPointMaximum = CalculateMaximumHitPoints(size, abilityScores, hitDieCount),
                HitDieCount = hitDieCount,
                HitDieSize = size.ToHitDie(),
            };
        }
    }
}