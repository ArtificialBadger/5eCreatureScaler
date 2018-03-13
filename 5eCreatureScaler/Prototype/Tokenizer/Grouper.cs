namespace CreatureScaler.Prototype.Tokenizer
{
    internal class Grouper : IGrouper
    {
        private int seed = 1;

        public int Current => seed;

        public int CreateNextGroup()
        {
            return seed++;
        }
    }
}