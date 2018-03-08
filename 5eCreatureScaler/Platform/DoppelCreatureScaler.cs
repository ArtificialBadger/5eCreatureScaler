using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreatureScaler.Models;

namespace CreatureScaler.Platform
{
    public class DoppelCreatureScaler : ICreatureScaler
    {
        public Creature ScaleCreature(Creature baseCreature, int targetCR)
        {
            //var newCreature = baseCreature.Clone();

            baseCreature.ChallengeRating = ChallengeRating.Create(targetCR);

            baseCreature.Actions.Add(new Models.Action() { Name = "Damage Enemy", Description = $"The {baseCreature.Name.ToLowerInvariant()} does damage to one creature equal to half of its maximum hit points." });

            return baseCreature;
        }
    }
}
