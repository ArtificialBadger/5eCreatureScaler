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
            var creature = Creature.Create("Thomas the Tank Engine", Size.Medium, ChallengeRating.Create(5), AbilityScore.CreateStandard(16, 9, 13, 1, 3, 25), 10);

            creature.ArmorClass = new ArmorClass(18, "Natural Armor");

            creature.DamageImmunities = new List<DamageType>() {DamageType.Fire, DamageType.Lightning, DamageType.Acid};
            creature.ConditionImmunities = new List<Condition>() {Condition.Blinded, Condition.Deafened, Condition.Prone};

            creature.Actions.Add(new CreatureScaler.Models.Action() {Name="Choo Choo", Description="Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit:5 (1d6+2) bludgeoning damage"} );
            creature.Actions.Add(new CreatureScaler.Models.Action() {Name="Steam Whistle", Recharge="Recharge 5-6", Description="Thomas blows hot steam in a 60-foot sphere centered on Thomas. Each creature in that area other than Thomas must make a DC 18 Dexterity saving throw, taking 35 (10d6) fire damage on a failed save, or half as much damage on a successful one."} );

            creature.Features.Add(new Feature() { Name="Antimagic Susceptibility", Description="Thomas is incapacitated while in the area of an anitmagic-field. If targeted by dispel magic, Thomas must suceed on a Constitution saving throw agains that caster's spell save DC or fall unconscious for 1 minute" });
            creature.Features.Add(new Feature() { Name="False Appearance", Description="While Thomas remains motionless, it is indistinguishable from a normal tank engine." });

            creature.Senses.Add(new Sense() { Range = 60, SenseType = SenseType.Truesight });
            creature.Senses.Add(new Sense() { Range = 120, SenseType = SenseType.Tremorsense});

            creature.Languages.Add(Language.Abyssal);
            creature.Languages.Add(Language.Celestial);
            creature.Languages.Add(Language.DeepSpeech);

            var creature2 = Creature.Create("Siggle", Size.Tiny, ChallengeRating.Create(1), AbilityScore.CreateStandard(8, 16, 10, 14, 11, 19), 4);

            creature2.Actions.Add(new Models.Action() {Name="Scratch", Description="Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit:3 (1d4+1) slashing damage" });

            var creatures = new CreatureList();
            creatures.Creatures = new List<Creature>() { creature, creature2 };

            return View("StatBlockView", creatures);
        }

        public IActionResult AnemicStatblock()
        {
            var creature = Creature.Create("Siggle", Size.Tiny, ChallengeRating.Create(1), AbilityScore.CreateStandard(8, 16, 10, 14, 11, 19), 4);

            creature.Actions.Add(new Models.Action() {Name="Scratch", Description="Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit:3 (1d4+1) slashing damage" });

            return View("StatBlockView", creature);
        }

        [HttpPost]
        public IActionResult Statblock(Creature creature)
        {
            return View("StatBlockView", creature);
        }
    }
}
