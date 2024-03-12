using MediatR;
using Mediaum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Commands
{
    public class CreateUserCommand : IRequest
    {
        public required string UserName { get; set; }
        public string? Name { get; set; }
        public string? Biography { get; set; }
        public string? Email { get; set; }
        public required string Login { get; set; }
        public string Password { get; set; }
        public string? PicturePath { get; set; }
        public int Followers { get; set; }
    }
}
