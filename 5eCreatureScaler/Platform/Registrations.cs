using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatureScaler.Platform
{
    public static class Registrations
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ICreatureResolver, StaticCreatureResolver>();
            services.AddTransient<ICreatureScaler, DoppelCreatureScaler>();
        }
    }
}
