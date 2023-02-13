using CoreService_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreService_backend.Services
{
    public class CoreServiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Resource> Resources { get; set; }

        public CoreServiceContext(DbContextOptions<CoreServiceContext> options) : base(options)
        {
        }

       

    }
}
