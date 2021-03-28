using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Commands.Desire.CreateDesire
{
    public class CreateDesireCommand : IRequest<DesireDto>
    {
        public DesireDto Dto { get; set; }

        public class CreateDesireCommandHandler : IRequestHandler<CreateDesireCommand, DesireDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateDesireCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DesireDto> Handle(CreateDesireCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Domain.Entities.Desire>(request.Dto);
                entity.CreatedAt = DateTime.Now;

                _context.Desires.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<DesireDto>(entity);
            }
        }
    }
}
