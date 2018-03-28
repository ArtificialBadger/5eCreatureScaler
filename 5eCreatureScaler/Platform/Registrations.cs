using CreatureScaler.Adjustors;
using CreatureScaler.Data;
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
            services.AddTransient<ICreatureScaler, ApexCreatureScaler>();
            services.AddTransient<IAdjustorSelector, AllAdjustorSelector>();

            services.AddTransient<MonsterByCRRepository>();
            services.AddTransient<CRCalculator>();

            services.AddTransient<ICreatureAdjustor, ArmorClassAdjustor>();
            //services.AddTransient<ICreatureAdjustor, SizeAdjustor>();
            //services.AddTransient<ICreatureAdjustor, StatisticAdjustor>();
        }
    }
}
