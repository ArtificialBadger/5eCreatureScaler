using CreatureScaler.Models;
using CreatureScaler.Platform;
using CreatureScaler.Rules;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Controllers
{
    public class StatblockController : Controller
    {
        public IActionResult Modrons()
        {
            var monodrone = new ViewModels.CreatureViewModel(StaticCreatureList.Monodrone);
            var duodrone = new ViewModels.CreatureViewModel(StaticCreatureList.Duodrone);
            var tridrone = new ViewModels.CreatureViewModel(StaticCreatureList.Tridrone);
            var quadrone = new ViewModels.CreatureViewModel(StaticCreatureList.Quadrone);
            var pentadrone = new ViewModels.CreatureViewModel(StaticCreatureList.Pentadrone);

            return View("StatBlockView", new List<ViewModels.CreatureViewModel>() { monodrone, duodrone, tridrone, quadrone, pentadrone });
        }

        public IActionResult Statblock()
        {
            var creature = Creature.Create("Thomas the Tank Engine", Size.Medium, ChallengeRating.Create(5), AbilityScore.CreateStandard(16, 9, 13, 1, 3, 25), 10);

            creature.Type = CreatureType.Construct;

            creature.ArmorClass = new ArmorClass(18, "Natural Armor");

            creature.Speeds = new List<Speed>() { new Speed(MovementMode.Walk, 60), new Speed(MovementMode.Swim, 120), new Speed(MovementMode.Burrow, 75) };

            creature.DamageImmunities = new List<DamageType>() { DamageType.Fire, DamageType.Lightning, DamageType.Acid };
            creature.ConditionImmunities = new List<Condition>() { Condition.Blinded, Condition.Deafened, Condition.Prone };

            var ramAttack = new Models.Action { Name = "Ram" };
            ramAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D8, 4, creature, Ability.Strength, DamageType.Bludgeoning);
            creature.Actions.Add(ramAttack);

            var chooChooAttack = new Models.Action() { Name = "Choo Choo" };
            chooChooAttack.RulesText = new RulesText() { Text = "Thomas does a big ol choo-choo thing. every targer in a 30 foot cone centered on him takes {dmg:2d8+str} {type:bludgeoning} damage and {dmg:1d8} {type:fire} damage" };
            //chooChooAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Strength, DamageType = DamageType.Bludgeoning, DamageDie = Die.D8, DamageDieCount = 2 });
            //chooChooAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.None, DamageType = DamageType.Fire, DamageDie = Die.D8, DamageDieCount = 1 });
            creature.Actions.Add(chooChooAttack);

            // creature.Actions.Add(new CreatureScaler.Models.Action() {Name="Choo Choo", Description="Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit:5 (1d6+2) bludgeoning damage"} );
            creature.Actions.Add(new Models.Action() { Name = "Steam Whistle", Recharge = "Recharge 5-6", RulesText = new RulesText() { Text = "Thomas blows hot steam in a 60-foot sphere centered on Thomas. Each creature in that area other than Thomas must make a DC 18 Dexterity saving throw, taking 35 (10d6) fire damage on a failed save, or half as much damage on a successful one." }});

            creature.Features.Add(new Feature() { Name = "Antimagic Susceptibility", Description = "Thomas is incapacitated while in the area of an anitmagic-field. If targeted by dispel magic, Thomas must suceed on a Constitution saving throw agains that caster's spell save DC or fall unconscious for 1 minute" });
            creature.Features.Add(new Feature() { Name = "False Appearance", Description = "While Thomas remains motionless, it is indistinguishable from a normal tank engine." });

            creature.Senses.Add(new Sense(SenseType.Truesight, 60));
            creature.Senses.Add(new Sense(SenseType.Tremorsense, 120));

            creature.Languages.Add(Language.Abyssal);
            creature.Languages.Add(Language.Celestial);
            creature.Languages.Add(Language.DeepSpeech);

            return View("StatBlockView", new List<ViewModels.CreatureViewModel>() { new ViewModels.CreatureViewModel(creature) });
        }

        [HttpPost]
        public IActionResult Statblock(Creature creature)
        {
            return View("StatBlockView", creature);
        }
    }
}
