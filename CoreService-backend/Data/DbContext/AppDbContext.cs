using CoreService_backend.Configurations.DbConfiguration;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Enitities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.DataAccess.DbContext
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResponseHandler> Response { get; set; }

        private readonly string? _connectionString =
            "Server = (localdb)\\mssqllocaldb;Database=CoreService;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";

        public AppDbContext(DbContextOptions options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}
