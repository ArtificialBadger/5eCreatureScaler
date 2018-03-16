using CreatureScaler.Models;

namespace CreatureScaler.Rules
{
    public abstract class Token : IRuleToken
    {
        public TokenContext Context { get; set; }

        public string Type => Context.Head;

        public abstract string TokenText { get; }

        public Token(TokenContext context)
        {
            this.Context = context;
        }

        public abstract string Format(Creature creature);

        public virtual int Attack(Creature creature)
        {
            return -1;
        }

        public virtual int DifficultyClass(Creature creature)
        {
            return -1;
        }

        public virtual int Damage(Creature creature)
        {
            return -1;
        }

        protected string Retokenize(string tokenValue)
        {
            return $"{{{Context.Head}:{tokenValue}}}";
        }
    }
}
