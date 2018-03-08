using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Models
{
    public sealed class MonsterExpectedStatRow
    {
        public double CR { get; set; }
        public int Prof { get; set; }
        public int AC { get; set; }
        public int HPMin { get; set; }
        public int HPMax { get; set; }
        public int Attack { get; set; }
        public int DprMin { get; set; }
        public int DprMax { get; set; }
        public int DC { get; set; }
    }
}
