using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWA.Application.Common.Exceptions;
using SWA.Application.Common.Interfaces;
using SWA.Application.SiteCollections.Queries.GetSiteCollections;
using SWA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.SiteCollections.Queries.GetSiteCollection
{
    public class GetSiteCollectionQuery :  IRequest<SiteCollectionsDto>
    {
        public int Id { get; set; }
    }

    public class GetSiteCollectionQueryHandler : IRequestHandler<GetSiteCollectionQuery, SiteCollectionsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetSiteCollectionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
        }

        public async Task<SiteCollectionsDto> Handle(GetSiteCollectionQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.SiteCollections
                .AsNoTracking()
                .Where(x => x.Id == request.Id)
                .ProjectTo<SiteCollectionsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            if(entity == null)
            {
                throw new NotFoundException(nameof(SiteCollection), request.Id);
            }

            return entity;
        }
    }
}
