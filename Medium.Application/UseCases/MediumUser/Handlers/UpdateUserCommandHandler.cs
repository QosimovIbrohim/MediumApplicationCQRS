using MediatR;
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
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public UpdateUserCommandHandler(IApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Users.FirstOrDefaultAsync(x=>x.Id == request.IdFinder && x.IsDeleted == false);
            if(res == null)
            {
                return "Not Found";
            }
            if(!_passwordHasher.Verify(res.PasswordHash,request.LastPassword,res.Salt))
            {
                return "Password incorrect";
            }    
            res.UserName = request.UserName;
            res.Name = request.Name;
            res.Email = request.Email;
            res.PicturePath = request.PicturePath;
            res.PasswordHash = _passwordHasher.Encrypt(request.Password,res.Salt);
            res.Biography = request.Biography;
            res.Login = request.Login;
            res.Followers = request.Followers;
            res.ModifiedDate = DateTimeOffset.UtcNow;
            _context.Users.Update(res);
            await _context.SaveChangesAsync(cancellationToken);
            return "Yangilandi";
        }
    }
}
