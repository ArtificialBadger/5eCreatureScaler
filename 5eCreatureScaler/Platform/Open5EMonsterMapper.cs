using CreatureScaler.Models;
using Open5ECreatureDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public sealed class Open5EMonsterMapper
    {
        private readonly Open5ECreatureDownloader.ICreatureDownloader downloader;

        public Open5EMonsterMapper(Open5ECreatureDownloader.ICreatureDownloader downloader)
        {
            this.downloader = downloader;
        }

        public Models.Creature Map(string uri)
        {
            var creature = downloader.DownloadCreature(uri);

            if (creature == default(Open5ECreatureDownloader.Creature))
            {
                return default(Models.Creature);
            }

            var mapped = new Models.Creature()
            {
                Alignment = ExtractAlignment(creature.Type),
                Actions = ExtractActions(creature.Actions),
            };

            throw new NotImplementedException();
        }

        internal static List<Models.Action> ExtractActions(string[] actions)
        {
            var multiattack = actions.FirstOrDefault(action => action.Has("multiattack"));

            throw new NotImplementedException();

        }

        internal static Alignment ExtractAlignment(string creatureTypeLine)
            => Enum
            .GetValues(typeof(Alignment))
            .Cast<Alignment>()
            .FirstOrDefault(alignment => creatureTypeLine.Has(alignment.ToString()));
    }
}
