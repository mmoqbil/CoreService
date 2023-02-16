using CoreService_backend.Enitities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreService_backend.Services.DbConfiguration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasData(
                new Resource
                {
                    Id = 1,
                    IpAdress = "127.0.0.1",
                    Name = "LocalHost",
                },
                new Resource
                {
                    Id = 2,
                    IpAdress = "187.166.70.216",
                    Name = "My private website",
                },
                new Resource
                {
                    Id = 3,
                    IpAdress = "40.214.147.21",
                    Name = "Some adress",
                },
                new Resource
                {
                    Id = 4,
                    IpAdress = "26.252.235.19",
                    Name = "My email service",
                },
                new Resource
                {
                    Id = 5,
                    IpAdress = "127.0.0.1",
                    Name = "Shop website",
                },
                new Resource
                {
                    Id = 6,
                    IpAdress = "175.189.43.59",
                    Name = "Coffee website",
                },
                new Resource
                {
                    Id = 7,
                    IpAdress = "148.143.234.67",
                    Name = "My car rent website",
                }
            );
        }
    }
}