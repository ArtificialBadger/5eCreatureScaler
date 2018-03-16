using CreatureScaler.Models;

namespace CreatureScaler.Tokenizer
{
    public interface ITokenizer
    {
        TokenizableRuleText Tokenize(string name, string ruleText, Creature creature);
    }
}