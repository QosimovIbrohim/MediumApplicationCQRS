using MediatR;
using Mediaum.Domain.Entities;
using Mediaum.Domain.Exceptions;
using Medium.Application.Abstractions;
using Medium.Application.UseCases.MediumUser.Querys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handlers
{
    public class GetUserByIdCommandQueryHandler : IRequestHandler<GetUserByIdCommandQuery, User>
    {
        private readonly IApplicationDbContext _context;

        public GetUserByIdCommandQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> Handle(GetUserByIdCommandQuery request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id && x.IsDeleted == false);
            if (res == null)
            {
                throw new _404NotFoundException("User not found");
            }
            return res;
        }
    }
}
