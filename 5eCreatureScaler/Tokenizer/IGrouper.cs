namespace CreatureScaler.Tokenizer
{
    public interface IGrouper
    {
        int Current { get; }

        int CreateNextGroup();
    }
}