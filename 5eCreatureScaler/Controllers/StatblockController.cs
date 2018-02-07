﻿using CreatureScaler.Models;
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
            var creature = Creature.Create("Crazy Train", Size.Medium, ChallengeRating.Create(5), 15, BasicStatistics.Create(14, 14, 14, 14, 14, 14), 10);

            return View("StatBlockView", creature);
        }

        [HttpPost]
        public IActionResult Statblock(Creature creature)
        {
            return View("StatBlockView", creature);
        }
    }
}
