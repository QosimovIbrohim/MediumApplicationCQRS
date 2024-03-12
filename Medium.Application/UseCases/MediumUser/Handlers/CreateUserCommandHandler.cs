using AutoMapper;
using MediatR;
using Mediaum.Domain.Entities;
using Mediaum.Domain.Exceptions;
using Medium.Application.Abstractions;
using Medium.Application.Mappers;
using Medium.Application.UseCases.MediumUser.Commands;

namespace Medium.Application.UseCases.MediumUser.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _pHash;
        public CreateUserCommandHandler(IApplicationDbContext context, IMapper mapper, IPasswordHasher pHash)
        {
            _context = context;
            _mapper = mapper;
            _pHash = pHash;
        }

        protected async override Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = request.MyMapp<User>();
                user.Salt = Guid.NewGuid().ToString("N");
                user.PasswordHash = _pHash.Encrypt(request.Password, user.Salt);
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw new SomethingWentWrongException("Something went wrong in Create");
            }
        }
    }
}
