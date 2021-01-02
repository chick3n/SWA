using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWA.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.SiteCollections.Queries.GetSiteCollections
{
    public class GetSiteCollectionsQuery : IRequest<SitesVm>
    {
    }

    public class GetSiteCollectionsQueryHandler : IRequestHandler<GetSiteCollectionsQuery, SitesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSiteCollectionsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SitesVm> Handle(GetSiteCollectionsQuery request, CancellationToken cancellationToken)
        {
            return new SitesVm
            {
                Collections = await _context.SiteCollections
                    .AsNoTracking()
                    .ProjectTo<SiteCollectionsDto>(_mapper.ConfigurationProvider)
                    .OrderBy(x => x.Name)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
