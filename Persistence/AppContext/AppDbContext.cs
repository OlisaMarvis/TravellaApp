using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.AppContext
{
    public class AppDbContext : IdentityDbContext, IAppDbContext
    {
        public DbSet<User>? Users { get; set; } 

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfigurations());
        }
        async Task<int> IAppDbContext.SaveChanges()
        {
            return await base.SaveChangesAsync();
        }

        
    }
}
