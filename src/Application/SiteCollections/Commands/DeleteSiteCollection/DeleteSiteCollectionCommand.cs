using MediatR;
using SWA.Application.Common.Exceptions;
using SWA.Application.Common.Interfaces;
using SWA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SWA.Application.SiteCollections.Commands.DeleteSiteCollection
{
    public class DeleteSiteCollectionCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteSiteCollectionCommandHandler : IRequestHandler<DeleteSiteCollectionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSiteCollectionCommandHandler(IApplicationDbContext context) => _context = context;

        public async Task<int> Handle(DeleteSiteCollectionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.SiteCollections.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(SiteCollection), request.Id);
            }

            _context.SiteCollections.Remove(entity);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
