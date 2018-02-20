using Open5ECreatureDownloader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public sealed class Open5EMonsterMapper
    {
        private readonly ICreatureDownloader downloader;

        public Open5EMonsterMapper(ICreatureDownloader downloader)
        {
            this.downloader = downloader;
        }

        public Models.Creature Map(string uri)
        {
            var creature = downloader.DownloadCreatures(uri).FirstOrDefault();

            if (creature == default(Open5ECreatureDownloader.Creature))
            {
                return default(Models.Creature);
            }

            throw new NotImplementedException();
        }
    }
}
