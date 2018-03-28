using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public class BasicCreatureScaler : ICreatureScaler
    {
        private readonly CRCalculator crCalculator;
        private readonly IEnumerable<ICreatureAdjustor> adjustors;

        public BasicCreatureScaler(CRCalculator crCalculator, IEnumerable<ICreatureAdjustor> adjustors)
        {
            this.crCalculator = crCalculator;
            this.adjustors = adjustors;
        }

        public Creature ScaleCreature(Creature baseCreature, int targetCR)
        {
            var calculatedCR = crCalculator.Calculate(baseCreature);

            var delta = calculatedCR;

            var newCreature = baseCreature.Clone();

            var selectedAdjustors = adjustors.Randomize(delta);

            foreach (var adjustor in selectedAdjustors)
            {
                adjustor.Adjust(newCreature);
            }

            return newCreature;
        }
    }
}
