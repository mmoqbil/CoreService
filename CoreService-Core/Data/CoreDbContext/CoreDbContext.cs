using CoreService_Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_Core.Data.CoreDbContext;

public class CoreDbContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }
    public DbSet<ResponseHandler> Response { get; set; }
    private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=CoreService;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
    // TODO: remove this CS

    public CoreDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging();
        }

        base.OnConfiguring(optionsBuilder);
    }
}