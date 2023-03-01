using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreService_Core.Data.CoreDbContext;
using CoreService_Core.Model.Entities;

namespace CoreService_Core.Service
{
    internal class ResponseRepository : IResponseRepository
    {
        private readonly CoreDbContext _context;
        private readonly IMapper _mapper;

        public ResponseRepository(CoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task createResponse(ResponseHandler response)
        {
            await _context.Response.AddAsync(response);
            await _context.SaveChangesAsync();
        }
    }
}
