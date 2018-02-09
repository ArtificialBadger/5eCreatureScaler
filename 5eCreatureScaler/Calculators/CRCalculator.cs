
using CreatureScaler.Models;
using System;
using System.Linq;

namespace CreatureScaler
{
    public class CRCalculator
    {
        public int Calculate(Creature creature)
        {
            var expectedValueTable = new[]
            {
                new { CR = 0f, Prof=2, AC=13, HPMin=1,HPMax=6, Attack= 3, DprMin=0, DprMax=1, DC= 13 },
                new { CR = 1/8f, Prof=2, AC=13, HPMin=7,HPMax=35, Attack= 3, DprMin=2, DprMax=3, DC= 13 },
                new { CR = 1/4f, Prof=2, AC=13, HPMin=36,HPMax=49, Attack= 3, DprMin=4, DprMax=5, DC= 13 },
                new { CR = 1/2f, Prof=2, AC=13, HPMin=50,HPMax=70, Attack= 3, DprMin=6, DprMax=8, DC= 13 },
                new { CR = 1f, Prof=2, AC=13, HPMin=71,HPMax=85, Attack= 3, DprMin=9, DprMax=14, DC= 13 },
                new { CR = 2f, Prof=2, AC=13, HPMin=86,HPMax=100, Attack= 3, DprMin=15, DprMax=20, DC= 13 },
                new { CR = 3f, Prof=2, AC=13, HPMin=101,HPMax=115, Attack= 4, DprMin=21, DprMax=26, DC= 13 },
                new { CR = 4f, Prof=2, AC=14, HPMin=116,HPMax=130, Attack= 5, DprMin=27, DprMax=32, DC= 14 },
                new { CR = 5f, Prof=3, AC=15, HPMin=131,HPMax=145, Attack= 6, DprMin=33, DprMax=38, DC= 15 },
                new { CR = 6f, Prof=3, AC=15, HPMin=146,HPMax=160, Attack= 6, DprMin=39, DprMax=44, DC= 15 },
                new { CR = 7f, Prof=3, AC=15, HPMin=161,HPMax=175, Attack= 6, DprMin=45, DprMax=50, DC= 15 },
                new { CR = 8f, Prof=3, AC=16, HPMin=176,HPMax=190, Attack= 7, DprMin=51, DprMax=56, DC= 16 },
                new { CR = 9f, Prof=4, AC=16, HPMin=191,HPMax=205, Attack= 7, DprMin=57, DprMax=62, DC= 16 },
                new { CR = 10f, Prof=4, AC=17, HPMin=206,HPMax=220, Attack= 7, DprMin=63, DprMax=68, DC= 16 },
                new { CR = 11f, Prof=4, AC=17, HPMin=221,HPMax=235, Attack= 8, DprMin=69, DprMax=74, DC= 17 },
                new { CR = 12f, Prof=4, AC=17, HPMin=236,HPMax=250, Attack= 8, DprMin=75, DprMax=80, DC= 17 },
                new { CR = 13f, Prof=5, AC=18, HPMin=251,HPMax=265, Attack= 8, DprMin=81, DprMax=86, DC= 18 },
                new { CR = 14f, Prof=5, AC=18, HPMin=266,HPMax=280, Attack= 8, DprMin=87, DprMax=92, DC= 18 },
                new { CR = 15f, Prof=5, AC=18, HPMin=281,HPMax=295, Attack= 8, DprMin=93, DprMax=98, DC= 18 },
                new { CR = 16f, Prof=5, AC=18, HPMin=296,HPMax=310, Attack= 9, DprMin=99, DprMax=104, DC= 18 },
                new { CR = 17f, Prof=6, AC=19, HPMin=311,HPMax=325, Attack= 10, DprMin=105, DprMax=110, DC= 19 },
                new { CR = 18f, Prof=6, AC=19, HPMin=326,HPMax=340, Attack= 10, DprMin=111, DprMax=116, DC= 19 },
                new { CR = 19f, Prof=6, AC=19, HPMin=341,HPMax=355, Attack= 10, DprMin=117, DprMax=122, DC= 19 },
                new { CR = 20f, Prof=6, AC=19, HPMin=356,HPMax=400, Attack= 10, DprMin=123, DprMax=140, DC= 19 },
                new { CR = 21f, Prof=7, AC=19, HPMin=401,HPMax=445, Attack= 11, DprMin=141, DprMax=158, DC= 20 },
                new { CR = 22f, Prof=7, AC=19, HPMin=446,HPMax=490, Attack= 11, DprMin=159, DprMax=176, DC= 20 },
                new { CR = 23f, Prof=7, AC=19, HPMin=491,HPMax=535, Attack= 11, DprMin=177, DprMax=194, DC= 20 },
                new { CR = 24f, Prof=7, AC=19, HPMin=536,HPMax=580, Attack= 12, DprMin=195, DprMax=212, DC= 21 },
                new { CR = 25f, Prof=8, AC=19, HPMin=581,HPMax=625, Attack= 12, DprMin=212, DprMax=230, DC= 21 },
                new { CR = 26f, Prof=8, AC=19, HPMin=626,HPMax=670, Attack= 12, DprMin=231, DprMax=248, DC= 21 },
                new { CR = 27f, Prof=8, AC=19, HPMin=671,HPMax=715, Attack= 13, DprMin=249, DprMax=266, DC= 22 },
                new { CR = 28f, Prof=8, AC=19, HPMin=716,HPMax=760, Attack= 13, DprMin=267, DprMax=284, DC= 22 },
                new { CR = 29f, Prof=9, AC=19, HPMin=761,HPMax=805, Attack= 13, DprMin=285, DprMax=302, DC= 22 },
                new { CR = 30f, Prof=9, AC=19, HPMin=806,HPMax=850, Attack= 14, DprMin=303, DprMax=320, DC= 23 },
            };

            // monster stats

            var hp = creature.Health.HitPointMaximum;
            var cr = creature.ChallengeRating.ListedChallengeRating;
            var ac = creature.ArmorClass;
            var dpr = creature.MaxDpr;
            var attack = creature.MaxAttack;

            // expected stats

            var expectedRow = expectedValueTable.Single(r => r.CR == cr);

            // defensive calculations

            var defensiveApparentCR = expectedValueTable.Where(r => r.HPMin <= hp).Single(r => r.HPMax >= hp).CR;
            var expectedArmorClass = expectedRow.AC;

            var differenceBetweenAC = ac - expectedArmorClass;
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