using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Models
{
    public sealed class Spellcasting
    {
        public Ability SpellcastingAbility
        {
            get;
            set;
        }

        public int SpellcasterLevel
        {
            get;
            set;
        }

        public List<Spell> PreparedSpells
        {
            get;
            set;
        } = new List<Spell>();
    }
}
