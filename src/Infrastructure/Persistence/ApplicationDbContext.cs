using Microsoft.EntityFrameworkCore;
using SWA.Application.Common.Interfaces;
using SWA.Domain.Entities;
using SWA.Infrastructure.Persistence.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<SiteCollection> SiteCollections { get; set; }
        public DbSet<DiscoveryObject> DiscoveryObjects { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new SiteCollectionConfiguration());
            builder.ApplyConfiguration(new DiscoveryObjectConfiguration());
        }
    }
}
