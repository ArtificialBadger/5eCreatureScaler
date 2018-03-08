using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Model
{
    public abstract class Token : IRuleToken
    {
        public TokenContext Context { get; set; }

        public string Type => Context.Head;

        public Token(TokenContext context)
        {
            this.Context = context;
        }

        public virtual string Format(Creature creature)
        {
            return Context.TokenValue;
        }

        public virtual int DifficultyClass(Creature creature)
        {
            return -1;
        }

        public virtual int Attack(Creature creature)
        {
            return -1;
        }

        public virtual int Damage(Creature creature)
        {
            return -1;
        }
    }
}
