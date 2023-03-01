using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreService_Core.Data.CoreDbContext;
using CoreService_Core.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreService_Core.Service
{
    internal class ResourceRepository : IResourceRepository
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;

        public ResourceRepository(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Resource>?> GetAllResourceAsync()
        {
            return await _context.Resources.AsNoTracking().ToListAsync();
        }
    }
}
