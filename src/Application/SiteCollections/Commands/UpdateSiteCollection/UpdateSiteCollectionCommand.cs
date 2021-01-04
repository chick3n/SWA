using MediatR;
using SWA.Application.Common.Exceptions;
using SWA.Application.Common.Interfaces;
using SWA.Domain.Entities;
using SWA.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.SiteCollections.Commands.UpdateSiteCollection
{
    public class UpdateSiteCollectionCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public SharePointType SharePointType { get; set; }
        public bool Enabled { get; set; }
    }

    public class UpdateSiteCollectionCommandHandler : IRequestHandler<UpdateSiteCollectionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSiteCollectionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSiteCollectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SiteCollections.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(SiteCollection), request.Id);
            }

            entity.Name = request.Name;
            entity.Url = request.Url;
            entity.SharepointType = request.SharePointType;
            entity.Enabled = request.Enabled;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
