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
                bear.Actions.Add(biteAttack);

                var clawsAttack = new Attack() { Name = "Claws", Reach = 5, AttackRollAbility = Ability.Strength };
                clawsAttack.DamageRolls.Add(new DamageRoll() { DamageDie = Die.D6, DamageDieCount = 2, AbilityModifier = Ability.Strength });
                bear.Actions.Add(clawsAttack);

                return bear;
            }
        }

    } 

}