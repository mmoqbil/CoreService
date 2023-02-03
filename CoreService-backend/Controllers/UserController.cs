using Microsoft.AspNetCore.Mvc;
using CoreService_backend.Dao;
using Serilog;
using CoreService_backend.Dtos;
using CoreService_backend.Services;
namespace CoreService_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _usersService;
        [HttpPost]
        [Route("registration")]
        public IActionResult Registration([FromBody] UserForCreationDto userDto)
        {
            var (userId, createdUserDto) = _usersService.CreateUser(userDto);

            return CreatedAtAction(nameof(User), new { userId = userId }, createdUserDto);
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
        public ActionResult<UserDto> GetUser(Guid userId)
        {
            var userDto = _usersService.GetUserById(userId);

            return Ok(userDto);
        }
    }
}
