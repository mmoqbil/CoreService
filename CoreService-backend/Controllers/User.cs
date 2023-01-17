using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Models;
using CoreService_backend.Dao;
namespace CoreService_backend.Controllers
{
    public class User : ControllerBase
    {
        UserList users = new UserList();
        [HttpPost]
        [Route("[controller]")]
        public void Post([FromBody] Models.User user)
        {
         users.Add(user);
        }
    }
}
