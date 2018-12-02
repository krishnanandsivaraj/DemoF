using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;

namespace DemoF.Web.Extensions
{
    using Persistence;
    using Migrations;

    public static class DbContextExtensions
    {
        public static void Seed(this DemofContext context, IWebHost host)
        {
            if (context.AllMigrationsApplied())
            {
                var seed = new Seeder(host, context);
                seed.Seed(host);
            }
        }

        public static bool AllMigrationsApplied(this DemofContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }
    }
}
