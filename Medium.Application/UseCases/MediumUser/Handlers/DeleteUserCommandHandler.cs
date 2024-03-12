﻿using MediatR;
using Medium.Application.Abstractions;
using Medium.Application.UseCases.MediumUser.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public DeleteUserCommandHandler(IApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (res == null)
            {
                return "User not found";
            }
            if (!_passwordHasher.Verify(res.PasswordHash, request.Password, res.Salt))
            {
                return "Password inncorrect";
            }
            res.IsDeleted = true;
            res.DeletedDate = DateTimeOffset.UtcNow;
            _context.Users.Update(res);
            await _context.SaveChangesAsync(cancellationToken);
            return "Deleted";
        }
    }
}
