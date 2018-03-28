using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    public class ApexCreatureScaler : ICreatureScaler
    {
        private IAdjustorSelector adjustorSelector;

        public ApexCreatureScaler(IAdjustorSelector adjustorSelector)
        {
            this.adjustorSelector = adjustorSelector;
        }

        public Creature ScaleCreature(Creature baseCreature, int targetCR)
        {
            var crToAdjustBy = targetCR - baseCreature.ChallengeRating.ListedChallengeRating;


            // Move O/D CR selection to own place
            var expectedOffensiveChallengeRating = targetCR;
            var expectedDefensiveChallengeRating = targetCR;

            var options = new CreatureAdjustmentOptions();
            options.ExpectedOffensiveChallengeRating = expectedOffensiveChallengeRating;
            options.ExpectedDefensiveChallengeRating = expectedDefensiveChallengeRating;

            var adjustors = adjustorSelector.SelectAdjustors(baseCreature, options);

            var newCreature = baseCreature.Clone();

            foreach (var adjustor in adjustors)
            {
                adjustor.Adjust(newCreature);
            }

            return newCreature;

        }
    }
}
