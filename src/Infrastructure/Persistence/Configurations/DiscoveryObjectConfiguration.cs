using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Infrastructure.Persistence.Configuration
{
    public class DiscoveryObjectConfiguration : IEntityTypeConfiguration<DiscoveryObject>
    {
        public void Configure(EntityTypeBuilder<DiscoveryObject> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.HasOne(x => x.SiteCollection)
                .WithMany(x => x.DiscoveryObjects)
                .HasForeignKey(x => x.SiteCollectionId);

            builder.Property(x => x.StaticName)
                .IsRequired();

            builder.Property(x => x.SiteName)
                .IsRequired();

            builder.Property(x => x.RelativePath)
                .IsRequired();

            builder.Property(x => x.DiscoveryType)
                .IsRequired();
        }
    }
}
