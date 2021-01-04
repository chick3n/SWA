using Microsoft.EntityFrameworkCore;
using SWA.Application.Common.Interfaces;
using SWA.Domain.Common;
using SWA.Domain.Entities;
using SWA.Infrastructure.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<SiteCollection> SiteCollections { get; set; }
        public DbSet<DiscoveryObject> DiscoveryObjects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.Modified = DateTime.UtcNow;
                        break;
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
