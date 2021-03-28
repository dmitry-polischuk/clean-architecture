using AutoMapper;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;
using System;

namespace CleanArchitecture.Application.Dto
{
    public class DesireDto : IMapFrom<Desire>
    {
        public Guid DesireId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DesireDto, Desire>()
                .ForMember(d => d.User, opt => opt.Ignore()); 

            profile.CreateMap<Desire, DesireDto>();
        }
    }
}
