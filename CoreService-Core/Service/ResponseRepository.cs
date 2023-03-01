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
    public class ResponseRepository : IResponseRepository
    {
        private readonly CoreDbContext _context;


        public ResponseRepository(CoreDbContext context)
        {
            _context = context;
        }

        public async Task CreateResponse(ResponseHandler response)
        {
            await _context.Response.AddAsync(response);
            await _context.SaveChangesAsync();
        }
    }
}
