using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SWA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWA.Infrastructure.Persistence.Configuration
{
    public class SiteCollectionConfiguration : IEntityTypeConfiguration<SiteCollection>
    {
        public void Configure(EntityTypeBuilder<SiteCollection> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.SharepointType)
                .IsRequired();

            builder.Property(x => x.Url)
                .IsRequired();
        }
    }
}
