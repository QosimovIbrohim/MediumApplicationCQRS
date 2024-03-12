using MediatR;
using Mediaum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medium.Application.UseCases.MediumUser.Querys
{
    public class GetAllUsersCommandQuery : IRequest<List<User>>
    {
    }
}
