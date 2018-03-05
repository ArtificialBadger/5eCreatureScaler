using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("5eCreatureScaler.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100e5c27db135b741685e0feb8bc62b7329239e55363d5c3a113613f85ab7bfd919179f0a99339540c18133160be6f328e0a3df6db812ea609106d84937e2927c26a74d252a7cf558c6591becac06a7b23b6adbef8367b7cb5f624fe4c45ddf74cbd6431db25c97ce4aec1f18258ebead9aacb001ab459355859d0fd0597380cac8")]

namespace CreatureScaler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
