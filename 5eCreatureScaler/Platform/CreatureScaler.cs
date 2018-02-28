using CreatureScaler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public class CreatureScaler
    {
        private readonly CRCalculator crCalculator;
        private readonly ICreatureAdjustor[] adjustors;

        public Creature ScaleCreature(Creature baseCreature, int targetCR)
        {
            var calculatedCR = crCalculator.Calculate(baseCreature);

            var delta = calculatedCR;

            var newCreature = baseCreature.Clone();

            var selectedAdjustors = adjustors.Randomize(delta);

            throw new NotImplementedException();
        }
    }
}
