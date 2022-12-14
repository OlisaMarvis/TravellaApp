using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppContext
{
    public interface IAppDbContext
    {
        DbSet<User>? Users { get; set; }
        Task<int> SaveChanges();
    }
}
