using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Dto
{
    public class UserDto : IMapFrom<User>
    {
        public string UserId { get; set; }
        public List<DeviceDto> Devices { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserDto, User>();
            profile.CreateMap<User, UserDto>();
        }
    }
}
