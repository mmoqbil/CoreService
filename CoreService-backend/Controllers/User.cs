using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Dao;
namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : ControllerBase
    {
        UserDao users = new UserDao();
        [HttpPost]
        [Route("registration")]
        public void Registration([FromBody] Models.User user)
        {
         users.Add(user);
        }
        [HttpPost]
        [Route("login")]
        public void Login([FromBody] Models.User user)
        {
            users.CheckLogin(user);
        }
    }
}
