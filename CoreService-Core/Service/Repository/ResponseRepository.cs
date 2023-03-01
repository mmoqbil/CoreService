using CoreService_Core.Data.CoreDbContext;
using CoreService_Core.Model.Entities;
using CoreService_Core.Service.Interface;

namespace CoreService_Core.Service.Repository
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
