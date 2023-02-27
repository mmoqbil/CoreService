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
                    Id = "1",
                    IpAdress = "127.0.0.1",
                    Name = "LocalHost",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                },
                new Resource
                {
                    Id = "2",
                    IpAdress = "187.166.70.216",
                    Name = "My private website",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                },
                new Resource
                {
                    Id = "3",
                    IpAdress = "40.214.147.21",
                    Name = "Some adress",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                },
                new Resource
                {
                    Id = "4",
                    IpAdress = "26.252.235.19",
                    Name = "My email service",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                },
                new Resource
                {
                    Id = "5",
                    IpAdress = "127.0.0.1",
                    Name = "Shop website",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                },
                new Resource
                {
                    Id = "6",
                    IpAdress = "175.189.43.59",
                    Name = "Coffee website",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                },
                new Resource
                {
                    Id = "7",
                    IpAdress = "148.143.234.67",
                    Name = "My car rent website",
                    UserId = "3d24fe63-559f-4302-93e0-693a4b12c9be",
                }
            );
        }
    }
}