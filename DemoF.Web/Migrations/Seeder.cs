using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoF.Web.Migrations
{
    using Core.Domain;
    using Persistence;

    public class Seeder
    {
        readonly DemofContext context;
        private readonly IHostingEnvironment _hostingEnv;

        public Seeder(IWebHost host, DemofContext context)
        {
            this.context = context;
        }

        public void Seed(IWebHost host)
        {
            var services = (IServiceScopeFactory)host.Services.GetService(typeof(IServiceScopeFactory));
            var serviceScope = services.CreateScope();

            context.Database.EnsureCreated();

            CreateUsers();
        }

        private void CreateUsers()
        {
            if (!context.Users.Any())
            {
                var user11 = new User()
                {
                    FirstName = "user11",
                    MiddleName = "user11",
                    LastName = "user11",
                    ValidFrom = DateTime.Now,
                    ValidUntill = DateTime.Now + TimeSpan.FromDays(30)
                };

                var user12 = new User()
                {
                    FirstName = "user12",
                    MiddleName = "user12",
                    LastName = "user12",
                    ValidFrom = DateTime.Now,
                    ValidUntill = DateTime.Now + TimeSpan.FromDays(30)
                };
                var user13 = new User()
                {
                    FirstName = "user13",
                    MiddleName = "user13",
                    LastName = "user13",
                    ValidFrom = DateTime.Now,
                    ValidUntill = DateTime.Now + TimeSpan.FromDays(30)
                };
                var user14 = new User()
                {
                    FirstName = "user14",
                    MiddleName = "user14",
                    LastName = "user14",
                    ValidFrom = DateTime.Now,
                    ValidUntill = DateTime.Now + TimeSpan.FromDays(30)
                };
                context.Users.AddRange(user11, user12, user13, user14);
                var r5 = context.SaveChanges();
            }
        }
    }
}
