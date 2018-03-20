namespace CreatureScaler.Tokenization
{
    public interface IGrouper
    {
        int Current { get; }

        int CreateNextGroup();
    }
}