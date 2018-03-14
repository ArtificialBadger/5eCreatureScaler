using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Prototype.Model
{
    public sealed class Action
    {
        public Action(string name, string recharge, ActionDescription description)
        {
            Name = name;
            Recharge = recharge;
            Description = description;
        }

        public Action(string name, ActionDescription description)
        {
            Name = name;
            Description = description;
        }

        public string Name
        {
            get;
            set;
        }

        public string Recharge
        {
            get;
            set;
        }

        public ActionDescription Description
        {
            get;
            set;
        }

        public IDictionary<string, int> MultiGroups
        {
            get;
            set;
        } = new Dictionary<string, int>();


        public double AverageDamagePerRound(Creature creature)
        {
            return this.Description.AverageAttack(creature);
        }

    }
}
