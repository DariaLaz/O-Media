using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Infrastructure.Data.EntityConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder.HasData(CreateUsers());
        }
        private List<IdentityUser> CreateUsers()
        {
            var users = new List<IdentityUser>();
            var hasher = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "admin@mail.com",
                NormalizedUserName = "admin@mail.com",
                Email = "admin@mail.com",
                NormalizedEmail = "admin@mail.com"

            };
            user.PasswordHash = hasher.HashPassword(user, "admin123");
            users.Add(user);
            user = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "user@mail.com",
                NormalizedUserName = "user@mail.com",
                Email = "user@mail.com",
                NormalizedEmail = "user@mail.com"

            };
            user.PasswordHash = hasher.HashPassword(user, "user123");
            users.Add(user);

            return users;
        }
    }
}
