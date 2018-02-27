using System;

namespace CreatureScaler.Platform
{
    public static class CreatureExtensions
    {
        public static bool Has(this string containerString, string containedString)
        {
            return containerString.IndexOf(containedString, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static Models.Creature ToCreatureModel(this Open5ECreatureDownloader.Creature creature)
        {
            throw new NotImplementedException();
        }
    }
}
