using DemoF.Persistence;
using DemoF.Web.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoF.Web.Migrations
{
    public class ProcessDbCommands
    {
        public static void Process(string[] args, IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            var seedService = (Seeder)host.Services.GetService(typeof(Seeder));

            using (var scope = services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<DemofContext>();
                db.Seed(host);
            }
        }
    }
}
