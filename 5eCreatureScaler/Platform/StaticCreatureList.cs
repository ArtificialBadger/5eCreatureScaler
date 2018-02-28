using CreatureScaler.Models;

namespace CreatureScaler.Platform
{

    public static class StaticCreatureList
    {
        public static Creature BrownBear
        {
            get
            {
                var bear = Creature.Create("BrownBear", Size.Large, ChallengeRating.Create(1), AbilityScore.CreateStandard(19, 10, 16, 2, 13, 7), 4);

                bear.Features.Add(new Feature() { Name = "Keen Smell", Description = "The bear has advantage on Wisdom (Perception) checks that rely on smell"});

                var biteAttack = new Attack() { Name = "Bite", Reach = 5, AttackRollAbility = Ability.Strength };
                biteAttack.DamageRolls.Add(new DamageRoll() { DamageDie = Die.D8, DamageDieCount = 1, AbilityModifier = Ability.Strength });
                bear.Attacks.Add(biteAttack);

                var clawsAttack = new Attack() { Name = "Claws", Reach = 5, AttackRollAbility = Ability.Strength };
                clawsAttack.DamageRolls.Add(new DamageRoll() { DamageDie = Die.D6, DamageDieCount = 2, AbilityModifier = Ability.Strength });
                bear.Attacks.Add(clawsAttack);

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

                creature.Speeds.Add(new Speed() { Mode = MovementMode.Walk, Distance = 30 });
                creature.Speeds.Add(new Speed() { Mode = MovementMode.Fly, Distance = 30 });

                creature.Senses.Add(new Sense() { SenseType = SenseType.Truesight, Range = 120 });

                creature.Languages.Add(Language.Modron);

                var clawAttack = new Attack() { Name = "Claw", AttackRollAbility = Ability.Dexterity, Reach = 5 };
                clawAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Dexterity, DamageType = DamageType.Slashing, DamageDie = Die.D6, DamageDieCount = 2 });
                clawAttack.MultiGroups.Add("melee", 2);
                creature.Attacks.Add(clawAttack);

                var spikeAttack = new Attack() { Name = "Spike Cannon", AttackRollAbility = Ability.Dexterity, AttackType = AttackType.RangedWeapon, Reach = 30 };
                spikeAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Dexterity, DamageType = DamageType.Piercing, DamageDie = Die.D10, DamageDieCount = 1 });
                spikeAttack.MultiGroups.Add("ranged", 2);
                creature.Attacks.Add(spikeAttack);

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

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

                creature.Speeds.Add(new Speed() { Mode = MovementMode.Walk, Distance = 30 });

                creature.Senses.Add(new Sense() { SenseType = SenseType.Truesight, Range = 120 });

                creature.Languages.Add(Language.Modron);

                var slamAttack = new Attack() { Name = "Slam", AttackRollAbility = Ability.Strength, Reach = 5 };
                slamAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Strength, DamageType = DamageType.Bludgeoning, DamageDie = Die.D8, DamageDieCount = 2 });
                slamAttack.MultiGroups.Add("melee", 2);
                creature.Attacks.Add(slamAttack);

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The duodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the duodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

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

                creature.Speeds.Add(new Speed() { Mode = MovementMode.Walk, Distance = 50 });

                creature.Senses.Add(new Sense() { SenseType = SenseType.Truesight, Range = 120 });

                creature.Languages.Add(Language.Modron);

                var cannonAttack = new Attack() { Name = "Cannon", AttackRollAbility = Ability.Strength, AttackType = AttackType.RangedWeapon, Reach = 120 };
                cannonAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.None, DamageType = DamageType.Bludgeoning, DamageDie = Die.D4, DamageDieCount = 3 });
                cannonAttack.MultiGroups.Add("ranged", 3);
                creature.Attacks.Add(cannonAttack);

                var buckShot = new Action() { Name = "Buckshot", Recharge = "5-6", Description = "The tridrone fires all nine cannons in its central cavity simultaniously in a 30 foot cone. Each creature in that area must succeed on a DC 14 Dexterity saving throw or take 19 (3d12) piercing damage or half as much on a successful save." };
                creature.Actions.Add(buckShot);

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The tridrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the tridrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

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

                creature.Speeds.Add(new Speed() { Mode = MovementMode.Walk, Distance = 40 });

                creature.Senses.Add(new Sense() { SenseType = SenseType.Truesight, Range = 120 });

                creature.Languages.Add(Language.Modron);

                var clawAttack = new Attack() { Name = "Claw", AttackRollAbility = Ability.Dexterity, Reach = 5 };
                clawAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Dexterity, DamageType = DamageType.Slashing, DamageDie = Die.D12, DamageDieCount = 2 });
                clawAttack.MultiGroups.Add("melee", 2);
                creature.Attacks.Add(clawAttack);

                var spikeAttack = new Attack() { Name = "Shoot Spike", AttackRollAbility = Ability.Dexterity, AttackType = AttackType.RangedWeapon, Reach = 30 };
                spikeAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Dexterity, DamageType = DamageType.Piercing, DamageDie = Die.D10, DamageDieCount = 1 });
                spikeAttack.MultiGroups.Add("ranged", 2);
                creature.Attacks.Add(spikeAttack);

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The quadrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the quadrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Pentadrone
        {
            get
            {
                var creature = Creature.Create("Pentadrone", Size.Large, ChallengeRating.Create(7), AbilityScore.CreateStandard(17, 22, 18, 11, 12, 13), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(20, "Natural Armor");

                creature.Speeds.Add(new Speed() { Mode = MovementMode.Walk, Distance = 30 });
                creature.Speeds.Add(new Speed() { Mode = MovementMode.Fly, Distance = 30 });

                creature.Senses.Add(new Sense() { SenseType = SenseType.Truesight, Range = 120 });

                creature.Languages.Add(Language.Modron);

                var clawAttack = new Attack() { Name = "Claw", AttackRollAbility = Ability.Dexterity, Reach = 5 };
                clawAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Dexterity, DamageType = DamageType.Slashing, DamageDie = Die.D6, DamageDieCount = 2 });
                clawAttack.MultiGroups.Add("melee", 2);
                creature.Attacks.Add(clawAttack);

                var spikeAttack = new Attack() { Name = "Shoot Spike", AttackRollAbility = Ability.Dexterity, AttackType = AttackType.RangedWeapon, Reach = 30 };
                spikeAttack.DamageRolls.Add(new DamageRoll() { AbilityModifier = Ability.Dexterity, DamageType = DamageType.Piercing, DamageDie = Die.D10, DamageDieCount = 1 });
                spikeAttack.MultiGroups.Add("ranged", 2);
                creature.Attacks.Add(spikeAttack);

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The pentadrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the pentadrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

    } 

}