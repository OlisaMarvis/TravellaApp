using Application.DTOs.Response;
using Domain.Entities;
using MediatR;
using Persistence.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.DeleteUser
{
    public class DeleteUserByIdHandler : IRequestHandler<DeleteUserByIdCommand, ApiResponseDTO<User>>
    {
        private readonly IAppDbContext _context;

        public DeleteUserByIdHandler(IAppDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseDTO<User>> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
        {
            var appUser = await DeleteSingleUser(command);
            return appUser;
        }

        private async Task<ApiResponseDTO<User>> DeleteSingleUser(DeleteUserByIdCommand command)
        {
            var getUser = _context.Users!.Where(x => x.UserId == command.UserId).FirstOrDefault();

            if (getUser == null)
                return new ApiResponseDTO<User> { Status = 404, Message = "User Not Found", Data = null! };

            _context.Users!.Remove(getUser);
            await _context.SaveChanges();

            return new ApiResponseDTO<User> { Status = 200, Message = "User Deleted Successfully", Data = null! };
        }
    }
}
