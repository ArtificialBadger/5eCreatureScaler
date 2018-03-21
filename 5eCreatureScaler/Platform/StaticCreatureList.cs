using CreatureScaler.Models;
using CreatureScaler.Rules;

namespace CreatureScaler.Platform
{

    public static class StaticCreatureList
    {
        public static Creature BrownBear
        {
            get
            {
                var bear = Creature.Create("BrownBear", Size.Large, ChallengeRating.Create(1), AbilityScore.CreateStandard(19, 10, 16, 2, 13, 7), 4);

                bear.ArmorClass = new ArmorClass() { Value = 11, Description = "Natural Armor" };

                bear.Speeds.Add(new Speed(MovementMode.Walk, 40));
                bear.Speeds.Add(new Speed(MovementMode.Climb, 30));

                bear.SkillProficiencies.Add(Skill.Perception);

                bear.Features.Add(new Feature() { Name = "Keen Smell", Description = "The bear has advantage on Wisdom (Perception) checks that rely on smell" });

                var biteAttack = new Action() { Name = "Bite" };
                biteAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D8, 1, bear, Ability.Strength, DamageType.Slashing);
                bear.Actions.Add(biteAttack);

                var clawsAttack = new Action() { Name = "Claws" };
                clawsAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D6, 2, bear, Ability.Strength, DamageType.Piercing);
                bear.Actions.Add(clawsAttack);

                return bear;
            }
        }

        public static Creature Monodrone
        {
            get
            {
                var creature = Creature.Create("Monodrone", Size.Medium, ChallengeRating.Create(2), AbilityScore.CreateStandard(12, 15, 13, 8, 11, 7), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(16, "Natural Armor");

                creature.Speeds.Add(new Speed(MovementMode.Walk, 30));
                creature.Speeds.Add(new Speed(MovementMode.Fly, 30));

                creature.Senses.Add(new Sense(SenseType.Truesight, 120));

                creature.Languages.Add(Language.Modron);

                var clawAttack = new Action() { Name = "Claw" };
                clawAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D6, 2, creature, Ability.Dexterity, DamageType.Slashing);
                clawAttack.MultiGroups.Add("melee", 2);
                creature.Actions.Add(clawAttack);

                var spikeAttack = new Action() { Name = "Spike Cannon" };
                spikeAttack.RulesText = RulesText.CreateMeleeAttack(30, Die.D6, 2, creature, Ability.Dexterity, DamageType.Piercing);
                spikeAttack.MultiGroups.Add("ranged", 2);
                creature.Actions.Add(spikeAttack);

                creature.Features.Add(new Feature() { Name = "Axiomatic Mind", Description = "The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name = "Disintegration", Description = "If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Duodrone
        {
            get
            {
                var creature = Creature.Create("Duodrone", Size.Medium, ChallengeRating.Create(3), AbilityScore.CreateStandard(16, 12, 14, 8, 11, 8), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

                creature.Speeds.Add(new Speed(MovementMode.Walk, 30));

                creature.Senses.Add(new Sense(SenseType.Truesight, 120));

                creature.Languages.Add(Language.Modron);

                var slamAttack = new Action() { Name = "Slam" };
                slamAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D8, 2, creature, Ability.Strength, DamageType.Bludgeoning);
                slamAttack.MultiGroups.Add("melee", 2);
                creature.Actions.Add(slamAttack);

                creature.Features.Add(new Feature() { Name = "Axiomatic Mind", Description = "The duodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name = "Disintegration", Description = "If the duodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Tridrone
        {
            get
            {
                var creature = Creature.Create("Tridrone", Size.Medium, ChallengeRating.Create(4), AbilityScore.CreateStandard(15, 13, 18, 9, 11, 10), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

                creature.Speeds.Add(new Speed(MovementMode.Walk, 50));

                creature.Senses.Add(new Sense(SenseType.Truesight, 120));

                creature.Languages.Add(Language.Modron);

                var cannonAttack = new Action() { Name = "Cannon" };
                cannonAttack.RulesText = RulesText.CreateMeleeAttack(120, Die.D4, 3, creature, Ability.None, DamageType.Bludgeoning);
                cannonAttack.MultiGroups.Add("ranged", 3);
                creature.Actions.Add(cannonAttack);

                var buckShot = new Action() { Name = "Buckshot", Recharge = "5-6" };
                buckShot.RulesText = new RulesText() { Text = "The tridrone fires all nine cannons in its central cavity simultaniously in a 30 foot cone. Each creature in that area must succeed on a DC 14 Dexterity saving throw or take 19 (3d12) piercing damage or half as much on a successful save." };
                creature.Actions.Add(buckShot);

                creature.Features.Add(new Feature() { Name = "Axiomatic Mind", Description = "The tridrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name = "Disintegration", Description = "If the tridrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Quadrone
        {
            get
            {
                var creature = Creature.Create("Quadrone", Size.Large, ChallengeRating.Create(5), AbilityScore.CreateStandard(18, 17, 18, 10, 11, 12), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(17, "Natural Armor");

                creature.Speeds.Add(new Speed(MovementMode.Walk, 40));

                creature.Senses.Add(new Sense(SenseType.Truesight, 120));

                creature.Languages.Add(Language.Modron);

                var clawAttack = new Action() { Name = "Claw" };
                clawAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D12, 2, creature, Ability.Strength, DamageType.Slashing);
                clawAttack.MultiGroups.Add("melee", 2);
                creature.Actions.Add(clawAttack);

                var oilSpray = new Action { Name = "Oil Spray", Recharge = "6" };
                oilSpray.RulesText = new RulesText() { Text = "The quadrone spews slick, boiling oil in a 20 foot cone. When the oil appears, each creature standing in its area must succeed on a DC 15 dexterity saving throw or take 18 (4d8) fire damage and fall prone. On a successful save, the creature takes half damage and does not fall prone. When the oil is ignited, it erupts into flames and everyone inside the oil takes 18 (4d8) fire damage." };
                creature.Actions.Add(oilSpray);

                creature.Features.Add(new Feature() { Name = "Axiomatic Mind", Description = "The quadrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name = "Disintegration", Description = "If the quadrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                var overheat = new Feature() { Name = "Overheat", Description = "When the quadron drops to 0 hitpoints and it has not taken cold damage on this turn, it becomes wreathed in flames and hot steam in a 20 foot sphere centered around itself. Each creature other than the quadrone in that area must make a DC 15 Constitution saving throw or take 27 (6d8) fire damage or half as much on a successful save. All flammable items not being worn or carried are ignited." };
                creature.Features.Add(overheat);

                return creature;
            }
        }

        public static Creature Pentadrone
        {
            get
            {
                var creature = Creature.Create("Pentadrone", Size.Large, ChallengeRating.Create(7), AbilityScore.CreateStandard(17, 22, 16, 11, 12, 13), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(20, "Natural Armor");

                creature.Speeds.Add(new Speed(MovementMode.Walk, 50));

                creature.Senses.Add(new Sense(SenseType.Truesight, 120));

                creature.Languages.Add(Language.Modron);

                var spearAttack = new Action() { Name = "Spear" };
                spearAttack.RulesText = RulesText.CreateMeleeAttack(10, Die.D8, 2, creature, Ability.Dexterity, DamageType.Piercing);
                spearAttack.MultiGroups.Add("melee", 1);
                creature.Actions.Add(spearAttack);

                var swordAttack = new Action() { Name = "Longsword" };
                swordAttack.RulesText = RulesText.CreateMeleeAttack(10, Die.D8, 2, creature, Ability.Dexterity, DamageType.Slashing);
                swordAttack.MultiGroups.Add("melee", 1);
                creature.Actions.Add(swordAttack);

                var punchAttack = new Action() { Name = "Punch" };
                punchAttack.RulesText = RulesText.CreateMeleeAttack(5, Die.D6, 2, creature, Ability.Dexterity, DamageType.Bludgeoning);
                punchAttack.MultiGroups.Add("melee", 1);
                creature.Actions.Add(punchAttack);

                creature.Features.Add(new Feature() { Name = "Axiomatic Mind", Description = "The pentadrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name = "Disintegration", Description = "If the pentadrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

    }

}