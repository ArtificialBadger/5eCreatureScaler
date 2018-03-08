using CreatureScaler.Data;
using CreatureScaler.Models;
using System;
using System.Linq;

namespace CreatureScaler.Platform
{
    public class CRCalculator
    {
        private readonly MonsterByCRRepository repository;

        public CRCalculator(MonsterByCRRepository repository)
        {
            this.repository = repository;
        }

        public int Calculate(Creature creature)
        {
            var expectedValueTable = repository.GetExpectedStats();

            // monster stats

            var hp = creature.Health;
            var cr = creature.ChallengeRating.ListedChallengeRating;
            var ac = creature.ArmorClass;
            var dpr = creature.MaxDpr;
            var attack = creature.MaxAttack;

            // expected stats

            var expectedRow = expectedValueTable.Single(r => r.CR == cr);

            // defensive calculations

            var defensiveApparentCR = expectedValueTable.Where(r => r.HPMin <= hp).Single(r => r.HPMax >= hp).CR;
            var expectedArmorClass = expectedRow.AC;

            var differenceBetweenAC = ac.Value - expectedArmorClass;
            var defensiveCRAdjustment = differenceBetweenAC / 2;

            var calculatedDefensiveCR = defensiveApparentCR + defensiveCRAdjustment;

            // offensive calculations

            var offensiveApparentCR = expectedValueTable.Where(r => r.DprMin <= dpr).Single(r => r.DprMax >= dpr).CR;
            var expectedAttack = expectedRow.Attack;

            var differenceBetweenAttack = attack - expectedAttack;
            var offensiveCRAdjustment = differenceBetweenAttack / 2;

            var calculatedOffensiveCR = offensiveApparentCR + offensiveCRAdjustment;

            // final calculation

            var finalCalculatedCR = Math.Round((calculatedOffensiveCR + calculatedDefensiveCR) / 2, MidpointRounding.AwayFromZero);

            return (int)finalCalculatedCR;
        }
    }
}