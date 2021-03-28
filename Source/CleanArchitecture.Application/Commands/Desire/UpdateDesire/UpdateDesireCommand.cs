using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PushNotificationService.Application.Desires.Command.UpdateDesire
{
    public class UpdateDesireCommand : IRequest
    {
        public DesireDto Dto { get; set; }
        public Guid DesireId { get; set; }
        public string Requestor { get; set; }

        public class UpdateDesireCommandHandler : IRequestHandler<UpdateDesireCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UpdateDesireCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateDesireCommand request, CancellationToken cancellationToken)
            {
                Desire targetDesire = await SelectDesireFromContext(request.DesireId);
                await UpdateDesire(request, targetDesire, cancellationToken);

                return Unit.Value;
            }

            private async Task UpdateDesire(UpdateDesireCommand request, Desire targetDesire, CancellationToken cancellationToken)
            {
                targetDesire.Name = request.Dto.Name;

                await _context.SaveChangesAsync(cancellationToken);
            }


            private async Task<Desire> SelectDesireFromContext(Guid DesireId)
            {
                var entity = await _context.Desires
                                .FirstOrDefaultAsync(r => r.DesireId == DesireId);

                _ = entity ?? throw new NotFoundException(nameof(Desire), DesireId);

                return entity;
            }
        }
        
    }
}
