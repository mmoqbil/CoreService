using CoreService_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

    }
}
