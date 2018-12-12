using System;
using Microsoft.EntityFrameworkCore;

namespace DemoF.Persistence
{
    using Core.Domain;

    public class DemofContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DemofContext(DbContextOptions<DemofContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("modelBuilder");
            }

            builder.Entity<User>().ToTable("Users").Property(p => p.Id).HasColumnName("Id");
        }
    }
}
