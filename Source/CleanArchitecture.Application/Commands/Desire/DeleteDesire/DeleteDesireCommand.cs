using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Desire.DeleteDesire
{
    public class DeleteDesireCommand : IRequest
    {
        public Guid DesireId { get; set; }
        public string RequestorId { get; set; }

        public class DeleteDesireCommandHandler : IRequestHandler<DeleteDesireCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteDesireCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteDesireCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Desire entity = await SelectDesire(request.DesireId);                

                await DeleteDesireFromDatabase(entity, cancellationToken);

                return Unit.Value;
            }

            private async Task<Domain.Entities.Desire> SelectDesire(Guid desireId)
            {
                var entity = await _context.Desires
                    .FirstOrDefaultAsync(r => r.DesireId == desireId);

                _ = entity ?? throw new NotFoundException(nameof(Desire), desireId);

                return entity;
            }

            private async Task DeleteDesireFromDatabase(Domain.Entities.Desire entity, CancellationToken cancellationToken)
            {
                _context.Desires.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
