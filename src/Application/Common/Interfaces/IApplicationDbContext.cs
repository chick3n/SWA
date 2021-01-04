using Microsoft.EntityFrameworkCore;
using SWA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SiteCollection> SiteCollections { get; set; }
        DbSet<DiscoveryObject> DiscoveryObjects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
