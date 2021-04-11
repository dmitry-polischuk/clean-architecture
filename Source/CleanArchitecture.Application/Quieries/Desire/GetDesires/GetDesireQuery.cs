using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Quieries.Desire
{
    public class GetDesireQuery : IRequest<IList<DesireDto>>
    {
        public string UserId { get; set; }
        public class GetDesiresQueryHandler : IRequestHandler<GetDesireQuery, IList<DesireDto>>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetDesiresQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IList<DesireDto>> Handle(GetDesireQuery request, CancellationToken cancellationToken)
            {
                var entities = await _context.Users
                    .Include(d => d.Desires)
                    .FirstOrDefaultAsync(nr => nr.UserId.ToString() == request.UserId);

                return _mapper.Map<IList<DesireDto>>(entities.Desires);
            }
        }
    }
}
