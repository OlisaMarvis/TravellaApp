using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserId);
            builder.Property(e => e.UserName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.FirstName).HasMaxLength(100).IsRequired();

            builder.HasData(
                new User
                {
                    UserId = new Guid(Guid.NewGuid().ToString()),
                    FirstName = "Okpala",
                    LastName = "Olisaemeka",
                    UserName = "marvis_encode",
                    Age = 29
                },
                new User
                {
                    UserId = new Guid(Guid.NewGuid().ToString()),
                    FirstName = "Okpala",
                    LastName = "Oli",
                    UserName = "marvis",
                    Age = 29
                },
                new User
                {
                    UserId = new Guid(Guid.NewGuid().ToString()),
                    FirstName = "Okp",
                    LastName = "Olisaemeka",
                    UserName = "encode",
                    Age = 29
                }
                );

        }
    }
}
