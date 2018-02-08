using CreatureScaler.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Controllers
{
    public class StatblockController : Controller
    {
        public IActionResult Test()
        {
            return Ok("You did Great!");
        }

        public IActionResult Statblock()
        {
            var creature = Creature.Create("Crazy Train", Size.Medium, ChallengeRating.Create(5), 15, AbilityScore.CreateStandard(16, 9, 13, 1, 3, 25), 10);

            creature.DamageImmunities = new List<DamageType>() {DamageType.Fire, DamageType.Lightning, DamageType.Acid};
            creature.ConditionImmunities = new List<Condition>() {Condition.Blinded, Condition.Deafened, Condition.Prone};

            return View("StatBlockView", creature);
        }

        [HttpPost]
        public IActionResult Statblock(Creature creature)
        {
            return View("StatBlockView", creature);
        }
    }
}
