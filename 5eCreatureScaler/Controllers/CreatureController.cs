using CreatureScaler.Models;
using CreatureScaler.Platform;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Controllers
{
    [Route("[controller]/[action]")]
    public class CreatureController : Controller
    {
        private ICreatureResolver creatureResolver;
        private ICreatureScaler creatureScaler;

        public CreatureController(ICreatureResolver creatureResolver, ICreatureScaler creatureScaler)
        {
            this.creatureResolver = creatureResolver;
            this.creatureScaler = creatureScaler;
        }

        [HttpGet("{creatureName}/{newChallengeRating:int}")]
        public IActionResult Scale(string creatureName, int newChallengeRating)
        {
            Creature scaledCreature;

            if (Guid.TryParse(creatureName, out Guid creatureGuid))
            {
                scaledCreature = creatureScaler.ScaleCreature(creatureResolver.ResolveCreature(creatureGuid), newChallengeRating);
            }
            else
            {
                scaledCreature = creatureScaler.ScaleCreature(creatureResolver.ResolveCreature(creatureName), newChallengeRating);
            }

            return View("StatBlockView", new List<ViewModels.CreatureViewModel>() { new ViewModels.CreatureViewModel(scaledCreature) });
        }
    }

}
