using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreService_Core.Data.CoreDbContext;
using CoreService_Core.Model.Entities;
using CoreService_Core.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CoreService_Core.Service.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly CoreDbContext _context;

        public ResourceRepository(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Resource>?> GetAllResourceAsync()
        {
            return await _context.Resources.AsNoTracking().ToListAsync();
        }
    }
}
