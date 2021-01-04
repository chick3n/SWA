using MediatR;
using SWA.Application.Common.Interfaces;
using SWA.Domain.Entities;
using SWA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.SiteCollections.Commands
{
    public class CreateSiteCollectionCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public SharePointType SharepointType { get; set; }
    }

    public class CreateSiteCollectionCommandHandler : IRequestHandler<CreateSiteCollectionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSiteCollectionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSiteCollectionCommand request, CancellationToken cancellationToken)
        {
            var entity = new SiteCollection
            {
                Name = request.Name,
                Url = request.Url,
                SharepointType = request.SharepointType,
                Enabled = true
            };

            _context.SiteCollections.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
