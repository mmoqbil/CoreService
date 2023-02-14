using CoreService_backend.Enitities;
using CoreService_backend.Services.DbConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.DataAccess.DbContext
{
    public class CoreServiceContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }

        private readonly string? _connectionString =
            "Server = (localdb)\\mssqllocaldb;Database=CoreService;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";

        public CoreServiceContext(DbContextOptions options) : base(options)
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
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
