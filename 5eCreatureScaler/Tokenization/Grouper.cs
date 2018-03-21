namespace CreatureScaler.Tokenization
{
    internal class Grouper : IGrouper
    {
        private int seed = 0;

        public int Current => seed;

        public int CreateNextGroup()
        {
            return seed++;
        }
    }
}