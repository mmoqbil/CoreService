using CoreService_Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_Core.Data.CoreDbContext
{
    internal class CoreDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResponseHandler> Response { get; set; }
        private readonly string? _connectionString =
            "Server = (localdb)\\mssqllocaldb;Database=CoreService;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";

        public CoreDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(_connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
