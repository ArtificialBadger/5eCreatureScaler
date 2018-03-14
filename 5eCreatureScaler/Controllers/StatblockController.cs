using CreatureScaler.Models;
using CreatureScaler.Platform;
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
            var monodrone = new ViewModels.Creature(StaticCreatureList.Monodrone);
            var duodrone = new ViewModels.Creature(StaticCreatureList.Duodrone);
            var tridrone = new ViewModels.Creature(StaticCreatureList.Tridrone);
            var quadrone = new ViewModels.Creature(StaticCreatureList.Quadrone);
            var pentadrone = new ViewModels.Creature(StaticCreatureList.Pentadrone);

            return View("StatBlockView", new List<ViewModels.Creature>() { monodrone, duodrone, tridrone, quadrone, pentadrone });
        }

        public IActionResult Statblock()
        {
            var creature = Creature.Create("Thomas the Tank Engine", Size.Medium, ChallengeRating.Create(5), AbilityScore.CreateStandard(16, 9, 13, 1, 3, 25), 10);

            creature.Type = CreatureType.Construct;

            creature.ArmorClass = new ArmorClass(18, "Natural Armor");

            creature.Speeds = new List<Speed>() { new Speed(MovementMode.Walk, 60), new Speed(MovementMode.Swim, 120), new Speed(MovementMode.Burrow, 75) };

            creature.DamageImmunities = new List<DamageType>() { DamageType.Fire, DamageType.Lightning, DamageType.Acid };
            creature.ConditionImmunities = new List<Condition>() { Condition.Blinded, Condition.Deafened, Condition.Prone };

            var ramAttack = new Attack() { Name = "Ram", AttackRollAbility = Ability.Strength, Reach = 5 };
            ramAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Strength, DamageType = DamageType.Bludgeoning, DamageDie = Die.D8, DamageDieCount = 2 });
            creature.Attacks.Add(ramAttack);

            var chooChooAttack = new Attack() { Name = "Choo Choo", AttackRollAbility = Ability.Strength, Reach = 30 };
            chooChooAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Strength, DamageType = DamageType.Bludgeoning, DamageDie = Die.D8, DamageDieCount = 2 });
            chooChooAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.None, DamageType = DamageType.Fire, DamageDie = Die.D8, DamageDieCount = 1 });
            creature.Attacks.Add(chooChooAttack);

            // creature.Actions.Add(new CreatureScaler.Models.Action() {Name="Choo Choo", Description="Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit:5 (1d6+2) bludgeoning damage"} );
            creature.Actions.Add(new Models.Action() { Name = "Steam Whistle", Recharge = "Recharge 5-6", Description = "Thomas blows hot steam in a 60-foot sphere centered on Thomas. Each creature in that area other than Thomas must make a DC 18 Dexterity saving throw, taking 35 (10d6) fire damage on a failed save, or half as much damage on a successful one." });

            creature.Features.Add(new Feature() { Name = "Antimagic Susceptibility", Description = "Thomas is incapacitated while in the area of an anitmagic-field. If targeted by dispel magic, Thomas must suceed on a Constitution saving throw agains that caster's spell save DC or fall unconscious for 1 minute" });
            creature.Features.Add(new Feature() { Name = "False Appearance", Description = "While Thomas remains motionless, it is indistinguishable from a normal tank engine." });

            creature.Senses.Add(new Sense(SenseType.Truesight, 60));
            creature.Senses.Add(new Sense(SenseType.Tremorsense, 120));

            creature.Languages.Add(Language.Abyssal);
            creature.Languages.Add(Language.Celestial);
            creature.Languages.Add(Language.DeepSpeech);

            return View("StatBlockView", new List<ViewModels.Creature>() { new ViewModels.Creature(creature) });
        }

        public IActionResult AnemicStatblock()
        {
            var creature = Creature.Create("Siggle", Size.Tiny, ChallengeRating.Create(1), AbilityScore.CreateStandard(8, 16, 10, 14, 11, 19), 4);

            creature.Actions.Add(new Models.Action() { Name = "Scratch", Description = "Melee Weapon Attack: +4 to hit, reach 5 ft., one target. Hit:3 (1d4+1) slashing damage" });

            return View("StatBlockView", creature);
        }

        public IActionResult Behir()
        {
            var behir = new Prototype.Model.Creature();

            behir.Name = "Behir";

            behir.Size = Size.Huge;
            behir.Type = CreatureType.Monstrosity;
            behir.Alignment = Alignment.NeutralEvil;

            behir.ArmorClass = new ArmorClass(17, "natural armor");
            behir.HitDieCount = 16;

            behir.Speeds.Add(new Speed(MovementMode.Walk, 50));
            behir.Speeds.Add(new Speed(MovementMode.Climb, 40));

            behir.Statistics = AbilityScore.CreateStandard(23, 16, 18, 7, 14, 12);

            behir.DamageImmunities.Add(DamageType.Lightning);

            behir.Senses.Add(new Sense(SenseType.Darkvision, 60));

            behir.Languages.Add(Language.Draconic);

            behir.ChallengeRating = ChallengeRating.Create(11);

            var biteAttack = new Prototype.Model.Action("Bite", new Prototype.Model.ActionDescription("Melee Weapon Attack: +10 to hit, reach 10ft., one target. Hit: 22(3d10 + 6) piercing damage. ", behir));
            biteAttack.MultiGroups.Add("melee", 1);

            var constrictAttack = new Prototype.Model.Action("Constrict", new Prototype.Model.ActionDescription("Melee Weapon Attack: + 10 to hit, reach 5 ft., one Large or smaller creature.Hit: 17(2d10 + 6) bludgeoning damage plus 17(2d10 + 6) slashing damage. The target is grappled (escape DC 16) if the behir isn't already constricting a creature, and the target is restrained until this grapple ends. ", behir));
            constrictAttack.MultiGroups.Add("melee", 1);

            var breathAttack = new Prototype.Model.Action("Lightning Breath", "5-6", new Prototype.Model.ActionDescription("The behir exhales a line of lightning that is 20 feet long and 5 feet wide.Each creature in that line must make a DC 16 Dexterity saving throw, taking 66(12d10) lightning damage on a failed save, or half as much damage on a successful one. ", behir));

            var swallowAttack = new Prototype.Model.Action("Swallow", new Prototype.Model.ActionDescription("The behir makes one bite attack against a Medium or smaller target it is grappling. If the attack hits, the target is also swallowed, and the grapple ends.While swallowed, the target is blinded and restrained, it has total cover against attacks and other effects outside the behir, and it takes 21(6d6) acid damage at the start of each of the behir's turns. A behir can have only one creature swallowed at a time. If the behir takes 30 damage or more on a single turn from the swallowed creature, the behir must succeed on a DC 14 Constitution saving throw at the end of that turn or regurgitate the creature, which fa lls prone in a space within 10 feet of the behir.If the behir dies, a swallowed creature is no longer restrained by it and can escape from the corpse by using 15 feet of movement, exiting prone. ", behir));

            behir.Actions.Add(biteAttack);
            behir.Actions.Add(constrictAttack);
            behir.Actions.Add(breathAttack);
            behir.Actions.Add(swallowAttack);

            return View("StatBlockView", new List<ViewModels.Creature>() { new ViewModels.Creature(behir) });
        }

        [HttpPost]
        public IActionResult Statblock(Creature creature)
        {
            return View("StatBlockView", creature);
        }
    }
}
