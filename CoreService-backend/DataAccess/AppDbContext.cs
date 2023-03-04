using CoreService_backend.Configurations.DbConfiguration;
using CoreService_backend.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.DataAccess;

public class AppDbContext : IdentityDbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<ResponseHandler> Response { get; set; }

    private readonly string _connectionString = "Server = (localdb)\\mssqllocaldb;Database=CoreService;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
    // TODO: remove this CS


    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string migrationsDirectory = @"Migrations\";

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