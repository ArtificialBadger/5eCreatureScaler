using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    internal class CreatureScaler : ICreatureScaler
    {
        private readonly CRCalculator crCalculator;
        private readonly ICreatureAdjustor[] adjustors;

        public CreatureScaler(CRCalculator crCalculator, ICreatureAdjustor[] adjustors)
        {
            this.crCalculator = crCalculator;
            this.adjustors = adjustors;
        }

        public Creature ScaleCreature(Creature baseCreature, int targetCR)
        {
            var calculatedCR = crCalculator.Calculate(baseCreature);

            var delta = targetCR - calculatedCR;

            var positive = delta > 0;

            var newCreature = baseCreature.Clone();

            var selectedAdjustors = adjustors.Randomize((uint)Math.Abs(delta));

            foreach (var adjustor in adjustors)
            {
                adjustor.Adjust(newCreature, positive);
            }

            return newCreature;
        }
    }
}
