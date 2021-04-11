using AutoMapper;
using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CleanArchitecture.Application.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Quieries.User.GetUser
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public GetUserQueryHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .Include(r => r.Devices)
                    .FirstOrDefaultAsync(r => r.UserId == request.UserId);

                _ = entity ?? throw new NotFoundException(nameof(User), request.UserId);

                return _mapper.Map<UserDto>(entity);
            }
        }
    }
}
