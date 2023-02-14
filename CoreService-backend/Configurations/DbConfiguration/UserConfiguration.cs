using CoreService_backend.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreService_backend.Services.DbConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "example@email.org",
                    Name = "Antony",
                    Password = "Example1"
                },
                new User
                {
                    Id = 2,
                    Email = "example2@gmail.org",
                    Name = "Adam",
                    Password = "Example2"
                },
                new User
                {
                    Id = 3,
                    Email = "example3@gmail.org",
                    Name = "Maciej",
                    Password = "Example3"
                },
                new User
                {
                    Id = 4,
                    Email = "example4@gmail.org",
                    Name = "Ryszard",
                    Password = "Example4"
                },
                new User
                {
                    Id = 5,
                    Email = "example5@gmail.org",
                    Name = "Piotr",
                    Password = "Example5"
                },
                new User
                {
                    Id = 6,
                    Email = "example6@gmail.org",
                    Name = "Natalia",
                    Password = "Example6"
                },
                new User
                {
                    Id = 7,
                    Email = "example6@gmail.org",
                    Name = "Karolina",
                    Password = "Example6"
                }
            );
        }
    }
}