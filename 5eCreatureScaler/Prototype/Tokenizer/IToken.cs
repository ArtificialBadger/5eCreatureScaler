using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Tokenizer
{
    public interface IToken
    {
        string Format(string tokenText, Creature creature);
    }
}
