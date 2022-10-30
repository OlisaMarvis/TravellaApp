using Application.DTOs.Response;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.AppContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<ApiResponseDTO<User>>
    {
        public Guid Id { get; set; }

        public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ApiResponseDTO<User>>
        {
            private readonly IAppDbContext _context;

            public GetUserByIdHandler(IAppDbContext context)
            {
               _context = context;
            }

            public async Task<ApiResponseDTO<User>> Handle(GetUserByIdQuery idQuery, CancellationToken cancellationToken)
            {
                var appUser = await _context.Users.Where(x => x.UserId == idQuery.Id).FirstOrDefaultAsync();
                if (appUser == null)
                    return new ApiResponseDTO<User> { Status = 404, Message = "AppUser Not Found", Data = appUser! };
                return new ApiResponseDTO<User> { Status = 200, Message = "User info retrieved", Data = appUser! };
            }
        }
    }
}
