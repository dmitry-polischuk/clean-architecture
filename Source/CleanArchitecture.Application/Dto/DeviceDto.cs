using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;

namespace CleanArchitecture.Application.Dto
{
    public class DeviceDto : IMapFrom<Device>
    {
        public Guid DeviceId { get; set; }
        public Guid UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeviceDto, Device>()
                .ForMember(d => d.User, opt => opt.Ignore());

            profile.CreateMap<Device, DeviceDto>();
        }
    }
}
