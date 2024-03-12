using MediatR;
using Mediaum.Domain.Entities;
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
    public class GetAllUsersCommandQueryHandler : IRequestHandler<GetAllUsersCommandQuery, List<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersCommandQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(GetAllUsersCommandQuery request, CancellationToken cancellationToken)
        {
            var s = _context.Users.Select(x => x).Where(s => s.IsDeleted == false);
            return await s.ToListAsync();
        }
    }
}
