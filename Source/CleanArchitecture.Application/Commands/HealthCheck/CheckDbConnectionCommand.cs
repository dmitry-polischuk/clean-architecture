using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Dto;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Common.Exceptions;
using MediatR;

namespace CleanArchitecture.Application.Commands.Healthcheck
{
    public class CheckDbConnectionCommand : IRequest
    {
        public class CheckDbConnectionCommandHandler : IRequestHandler<CheckDbConnectionCommand>
        {
            private readonly IApplicationDbContext _context;
            public CheckDbConnectionCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(CheckDbConnectionCommand request, CancellationToken cancellationToken)
            {
                bool result = await _context.CheckDbConnection();
                if (!result)
                    throw new InternalServerException("Error - unable to establish connection");
                else
                    return Unit.Value;
            }

        }
    }
}
