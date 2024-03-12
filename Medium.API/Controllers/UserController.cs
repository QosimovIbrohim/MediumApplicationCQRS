using AutoMapper;
using MediatR;
using Mediaum.Domain.Entities;
using Medium.Application.UseCases.MediumUser.Commands;
using Medium.Application.UseCases.MediumUser.Querys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medium.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateUser(CreateUserCommand cuc)
        {
            var s = await _mediator.Send(cuc);
        }
        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            var s = await _mediator.Send(new GetAllUsersCommandQuery());
            return s;
        }
        [HttpGet]
        public async Task<User> GetUserById(int id)
        {
            var s = await _mediator.Send(new GetUserByIdCommandQuery() { Id = id});
            return s;
        }
        [HttpDelete]
        public async Task<string> DeleteUser(DeleteUserCommand dl)
        {
            var s = await _mediator.Send(dl);
            return s;
        }
        [HttpPut]
        public async Task<string> Update(UpdateUserCommand uuc)
        {
            var s = await _mediator.Send(uuc);
            return s;
        }
    }
}
