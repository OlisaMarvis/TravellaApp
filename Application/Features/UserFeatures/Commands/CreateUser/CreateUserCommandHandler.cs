using Application.DTOs.Response;
using Domain.Entities;
using MediatR;
using Persistence.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponseDTO<User>>
    {
        private readonly IAppDbContext _context;

        public CreateUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseDTO<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var appUser = await CreateNewUser(command);
            return appUser;
        }

        private async Task<ApiResponseDTO<User>> CreateNewUser(CreateUserCommand command)
        {
            var createdUser = new User();
            createdUser.UserName = command.UserName;
            createdUser.FirstName = command.LastName;
            createdUser.LastName = command.FirstName;
            createdUser.Address = command.Address;
            createdUser.Phone = command.Phone;
            createdUser.Email = command.Email;
            createdUser.City = command.City;
            createdUser.Age = command.Age;
            createdUser.Country = command.Country;
            createdUser.PostalCode = command.PostalCode;
            createdUser.State = command.State;

            _context.Users.Add(createdUser);
            await _context.SaveChanges();

            return new ApiResponseDTO<User> { Status = 200, Message = "User Created Successfully!" };
        }
    }
}
