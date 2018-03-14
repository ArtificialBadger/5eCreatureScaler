namespace CreatureScaler.Models
{
    public sealed class Speed
    {
        public Speed(MovementMode Mode, int Distance)
        {
            this.Mode = Mode;
            this.Distance = Distance;
        }

        public MovementMode Mode
        {
            get;
            set;
        }

        public int Distance
        {
            get;
            set;
        }
    }
}