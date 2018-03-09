using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class AttackBonusSuggestion : IToken
    {
        public static string Pattern => @"\+[0-9]+ to hit";

        public string Format(string tokenText, Creature creature)
        {
            var output = creature.FindModString(tokenText);

            return output == default(string) ? tokenText : $"{{attack:{output}}} to hit";
        }
    }
}


