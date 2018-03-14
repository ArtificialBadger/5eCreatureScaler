namespace CreatureScaler.Models
{
    public sealed class Sense
    {
        public Sense(SenseType senseType, int range)
        {
            SenseType = senseType;
            Range = range;
        }

        public SenseType SenseType
        {
            get;
            set;
        }

        public int Range
        {
            get;
            set;
        }
    }
}