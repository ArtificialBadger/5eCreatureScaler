using Newtonsoft.Json;
using System;

namespace CreatureScaler.Platform
{
    public static class CreatureExtensions
    {
        public static bool Has(this string containerString, string containedString)
        {
            return containerString.IndexOf(containedString, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static Models.Creature Clone(this Models.Creature creature)
        {
            return JsonConvert.DeserializeObject<Models.Creature>(JsonConvert.SerializeObject(creature));
        }
    }
}
