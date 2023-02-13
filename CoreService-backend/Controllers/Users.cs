using Microsoft.AspNetCore.Mvc;
using Serilog;
using CoreService_backend.Dtos;
using CoreService_backend.Models;
using CoreService_backend.Services;

namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Users : ControllerBase
    {
        
        private readonly IUserService _usersService;

        public Users(IUserService usersService)
        {
            _usersService = usersService;
        }


        [HttpPost]
        [Route("registration")]
        public IActionResult Registration([FromBody] User user)
        {
            var (userId, createdUserDto) = _usersService.CreateUser(user);

            return CreatedAtAction(nameof(GetUser), new { userId = userId }, createdUserDto);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            var usersDto = _usersService.GetUsers();

            return Ok(usersDto);
        }

        [HttpGet("{userId:guid}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UserDto> GetUser(long userId)
        {
            var userDto = _usersService.GetUserById(userId);

            return Ok(userDto);
        }
    }
}
