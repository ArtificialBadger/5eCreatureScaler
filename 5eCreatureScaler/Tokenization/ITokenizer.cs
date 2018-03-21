using CreatureScaler.Models;

namespace CreatureScaler.Tokenization
{
    public interface ITokenizer
    {
        TokenizableRuleText Tokenize(string name, string ruleText, Creature creature);
    }
}