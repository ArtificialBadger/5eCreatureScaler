using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Tokenizer
{
    public class DamageTypeCandidateToken : IToken
    {
        public static string Pattern => @"(acid|bludgeoning|cold|fire|force|lightning|necrotic|piercing|poison|psychic|radiant|slashing|thunder) damage";

        public string Format(string tokenText, Creature creature)
        {
            var type = tokenText.Split(' ')[0];

            return $"{{type:{type}}} damage";
        }
    }
}
