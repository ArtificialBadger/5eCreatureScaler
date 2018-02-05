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
            return View("StatBlockView");
        }
    }
}
