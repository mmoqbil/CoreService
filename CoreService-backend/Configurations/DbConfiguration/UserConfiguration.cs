using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreService_backend.Configurations.DbConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        var passwordHasher = new PasswordHasher<IdentityUser>();

        builder.HasData(
            new IdentityUser
            {
                UserName = "johndoe",
                Email = "johndoe@example.com",
                PasswordHash = passwordHasher.HashPassword(null, "example"),
            },
            new IdentityUser
            {
                UserName = "Adam",
                Email = "adam@example.com",
                PasswordHash = passwordHasher.HashPassword(null, "example"),
            },
            new IdentityUser
            {
                UserName = "Judasz",
                Email = "judasz@example.com",
                PasswordHash = passwordHasher.HashPassword(null, "example"),
            }
        );
    }
}