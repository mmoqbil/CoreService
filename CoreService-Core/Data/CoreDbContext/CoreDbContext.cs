using CoreService_Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_Core.Data.CoreDbContext
{
    internal class CoreDbContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResponseHandler> Response { get; set; }

        public CoreDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
