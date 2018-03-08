using System.Collections.Generic;

namespace CreatureScaler.Models
{
    public sealed class InnateSpellcasting
    {
        public Ability SpellcastingAbility { get; set; }

        public List<InnateSpell> InnateSpells { get; set; }
    }
}