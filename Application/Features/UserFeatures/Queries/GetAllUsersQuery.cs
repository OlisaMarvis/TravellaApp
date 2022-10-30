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
    public partial class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetAllUsersHandler :  IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
        {
            private readonly IAppDbContext _context;

            public GetAllUsersHandler(IAppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var appUsers = await _context.Users!.ToListAsync();
                return appUsers!;
            }
        }

        
    }
}
