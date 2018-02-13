using CreatureScaler.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Controllers
{
    public class CreatureController : Controller
    {
        [HttpGet]
        public IActionResult ScaleCreature(int creatureId, int newChallengeRating )
        {
            return Ok($"Statblock for creature with id: {creatureId} scaled to: {newChallengeRating}");
        }
    }

}
