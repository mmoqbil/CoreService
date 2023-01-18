using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Dao;
using Newtonsoft.Json;

namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Resource : ControllerBase
    {
        ResourceDao _resource = new ResourceDao();
        [HttpPost]
        [Route("resources")]
        public string GetData()
        {
            _resource.Add(new Models.Resource() { Name = "FirstResource" });
            return JsonConvert.SerializeObject(_resource);
        }
    }
}
