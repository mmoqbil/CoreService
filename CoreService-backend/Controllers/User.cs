using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Dao;
using Serilog;
namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class User : ControllerBase
    {
        private UserDao _users = new UserDao();
        [HttpPost]
        [Route("registration")]
        public void Registration([FromBody] Models.User user)
        {
            try
            {
                Log.Information("Registering new user");
                _users.Add(new Models.User(user.Email, user.Name, user.Password, user.PasswordConfirmation));
                var data = _users.GetAll();
                foreach (var key in data)
                {
                    Console.WriteLine(key.Name);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in creating Order object.");
            }
        }

        [HttpPost]
        [Route("login")]
        public void Login([FromBody] Models.User user)
        {
            try
            {
                Log.Information("Trying to login");
                _users.CheckLogin(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error with login");
            }
        }

        [HttpPost]
        [Route("changelogin")]
        public void ChangeLogin([FromBody] Models.User user)
        {
            try
            {
                Log.Information("Trying to change login");
                _users.UpdateLogin(user);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Error with changing login");
            }
        }

        [HttpPost]
        [Route("changepassword")]
        public void ChangePassword([FromBody] Models.User user)
        {
            try
            {
                Log.Information("Trying to change password");
                _users.UpdatePassword(user);
            }
            catch(Exception ex)
            {
                Log.Error(ex, "Error with changing password");
            }
        }
    }
}
