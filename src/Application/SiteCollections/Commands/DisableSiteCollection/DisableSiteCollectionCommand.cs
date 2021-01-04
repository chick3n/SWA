using MediatR;
using SWA.Application.Common.Exceptions;
using SWA.Application.Common.Interfaces;
using SWA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.SiteCollections.Commands.DisableSiteCollection
{
    public class DisableSiteCollectionCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DisableSiteCollectionCommandHandler : IRequestHandler<DisableSiteCollectionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DisableSiteCollectionCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<int> Handle(DisableSiteCollectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SiteCollections.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(SiteCollection), request.Id);
            }

            entity.Enabled = false;

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
