using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.CQRS.Devices.Command.RegisterDevice
{
    public class RegisterDeviceCommand : IRequest<DeviceDto>
    {
        public DeviceDto Dto { get; set; }
        public class RegisterDeviceCommandHandler : IRequestHandler<RegisterDeviceCommand, DeviceDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public RegisterDeviceCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DeviceDto> Handle(RegisterDeviceCommand request, CancellationToken cancellationToken)
            {
                var deviceEntity = await _context.Devices.FirstOrDefaultAsync(d => d.DeviceId == request.Dto.DeviceId);
                
                if(deviceEntity == null)
                {
                    return await RegisterNewDevice(request.Dto, cancellationToken);
                }
                else
                {
                    return await UpdateDeviceToken(deviceEntity, request.Dto, cancellationToken);
                }  
            }

            private async Task<DeviceDto> RegisterNewDevice(DeviceDto device, CancellationToken cancellationToken)
            {
                var userEntity = await _context.Users
                    .Include(u => u.Devices)
                    .FirstOrDefaultAsync(u => u.UserId == device.UserId);

                if (userEntity == null)
                {
                    return await InsertNewUserWithNewDevice(device, cancellationToken);
                }
                else
                {
                    return await InsertNewDeviceToExistingUser(device, userEntity, cancellationToken);
                }
            }

            private async Task<DeviceDto> InsertNewUserWithNewDevice(DeviceDto deviceDto, CancellationToken cancellationToken)
            {
                var device = _mapper.Map<Device>(deviceDto);
                User userEntity = new User
                {
                    UserId = device.UserId,
                    Devices = new System.Collections.Generic.List<Device>()
                    {
                        device
                    }
                };

                _context.Users.Add(userEntity);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<DeviceDto>(device);
            }

            private async Task<DeviceDto> InsertNewDeviceToExistingUser(DeviceDto deviceDto, User user, CancellationToken cancellationToken)
            {
                if (deviceDto.UserId != user.UserId)
                {
                    throw new BadRequestException($"Device ({deviceDto.DeviceId}) already registered for another user.");
                }

                var device = _mapper.Map<Device>(deviceDto);
                user.Devices.Add(device);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<DeviceDto>(device);
            }

            private async Task<DeviceDto> UpdateDeviceToken(Device device, DeviceDto dto, CancellationToken cancellationToken)
            {
                if (device.UserId != dto.UserId)
                {
                    throw new BadRequestException($"Device ({dto.DeviceId}) already registered for another user.");
                }

                _context.Devices.Update(device);
                await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<DeviceDto>(device);
            }
        }
    }
}
