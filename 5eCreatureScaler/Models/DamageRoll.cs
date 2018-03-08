namespace CreatureScaler.Models
{
    public sealed class DamageRoll
    {
        public Die DamageDie 
        { 
            get; 
            set; 
        }

        public int DamageDieCount 
        { 
            get; 
            set; 
        }

        public Ability AbilityModifier 
        { 
            get; 
            set; 
        }

        public DamageType DamageType 
        { 
            get; 
            set;
        }

        public int ToAverageDamage()
        {
            return (int)(DamageDieCount * DamageDie.ToAverageValue());
        }
    }
}