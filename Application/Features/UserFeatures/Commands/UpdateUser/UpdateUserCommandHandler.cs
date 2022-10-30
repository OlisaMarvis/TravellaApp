using Application.DTOs.Response;
using Domain.Entities;
using MediatR;
using Persistence.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ApiResponseDTO<User>>
    {
        private readonly IAppDbContext _context;

        public UpdateUserCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseDTO<User>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var appUser = await UpdateAUser(command);
            return appUser;
        }

        private async Task<ApiResponseDTO<User>> UpdateAUser(UpdateUserCommand command)
        {
            var appUser = _context.Users!.Where(x => x.UserId == command.UserId).FirstOrDefault();

            if (appUser != null)
            {
                appUser.FirstName = command.FirstName;
                appUser.LastName = command.LastName;
                appUser.Age = command.Age;
                appUser.Email = command.Email;
                appUser.UserName = command.UserName;
                appUser.Country = command.Country;
                appUser.Phone = command.Phone;


                await _context.SaveChanges();
                return new ApiResponseDTO<User> { Status = 200, Message = "User Info Updated Successfully" };
            }
            return new ApiResponseDTO<User> { Status = 400, Message = "User Not Found, update failed" };
        }
    }
}
