using System.ComponentModel.DataAnnotations;

namespace CoreService_backend.Dtos
{
    public class UserForCreationDto
    {
        public string Email { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }
    }

    public class UserForUpdateDto : UserForCreationDto
    {

    }

    public class UserForBulkUpdateDto : UserForUpdateDto
    {
        public int Id { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
