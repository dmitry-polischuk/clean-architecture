using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Devices.Command.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest
    {
        public Guid DeviceId { get; set; }

        public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public DeleteDeviceCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
            {
                var deviceEntity = await _context.Devices
                    .FirstOrDefaultAsync(u => u.DeviceId == request.DeviceId);

                if (deviceEntity == null)
                {
                    throw new NotFoundException(nameof(Device), request.DeviceId);
                }

                _context.Devices.Remove(deviceEntity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }

        }
    }
}
