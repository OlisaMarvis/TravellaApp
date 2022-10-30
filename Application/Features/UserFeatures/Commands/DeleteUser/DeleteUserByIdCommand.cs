using Application.DTOs.Response;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Commands.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest<ApiResponseDTO<User>>
    {
        public Guid UserId { get; set; }
    }
}
