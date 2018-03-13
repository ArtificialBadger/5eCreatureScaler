namespace CreatureScaler.Prototype.Tokenizer
{
    public interface IGrouper
    {
        int Current { get; }

        int CreateNextGroup();
    }
}