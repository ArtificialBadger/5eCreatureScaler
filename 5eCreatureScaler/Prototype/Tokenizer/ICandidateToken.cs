using CreatureScaler.Models;

namespace CreatureScaler.Prototype.Tokenizer
{
    public interface ICandidateToken
    {
        string TokenText { get; }

        bool Accepted { get; }

        void Accept();

        void Unaccept();

        string Format(Creature creature);
    }
}
