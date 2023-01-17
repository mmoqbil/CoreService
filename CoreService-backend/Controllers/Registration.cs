using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Models;
using CoreService_backend.Dao;
namespace CoreService_backend.Controllers
{
    public class Registration : ControllerBase
    {
        UserList users = new UserList();
        [HttpPost]
        public void Post([FromBody] User user)
        {
         users.Add(user);
        }
    }
}
