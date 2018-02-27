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

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

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

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Duodrone
        {
            get
            {
                var creature = Creature.Create("Duodrone", Size.Medium, ChallengeRating.Create(3), AbilityScore.CreateStandard(12, 15, 13, 8, 11, 7), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

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

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Tridrone
        {
            get
            {
                var creature = Creature.Create("Tridrone", Size.Medium, ChallengeRating.Create(4), AbilityScore.CreateStandard(12, 15, 13, 8, 11, 7), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

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

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Quadrone
        {
            get
            {
                var creature = Creature.Create("Quadrone", Size.Medium, ChallengeRating.Create(5), AbilityScore.CreateStandard(12, 15, 13, 8, 11, 7), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

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

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

        public static Creature Pentadrone
        {
            get
            {
                var creature = Creature.Create("Pentadrone", Size.Large, ChallengeRating.Create(7), AbilityScore.CreateStandard(12, 15, 13, 8, 11, 7), 15);

                creature.Type = CreatureType.Construct;

                creature.Alignment = Alignment.LawfulNeutral;

                creature.ArmorClass = new ArmorClass(15, "Natural Armor");

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

                creature.Features.Add(new Feature() { Name="Axiomatic Mind", Description="The monodrone can't be compelled to act in a manner contrary to its nature or its instructions." });
                creature.Features.Add(new Feature() { Name="Disintegration", Description="If the monodrone dies, its body disintegrates into dust, leaving behind its weapons and anything else it was carrying." });

                return creature;
            }
        }

    } 

}