using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreService_backend.Configurations.DbConfiguration;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2",
                Name = "SuperUser",
                NormalizedName = "SUPERUSER"
            },
            new IdentityRole
            {
                Id = "3",
                Name = "User",
                NormalizedName = "USER"
            });
    }
}