using System.ComponentModel.DataAnnotations;

namespace CoreService_backend.Dtos
{
    public class UserForCreationDto
    {
        [Required]
        [MaxLength(52)]
        public string Email { get; set; }

        [Required]
        [MaxLength(52)]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; }

        [Required]
        [MaxLength(128)]
        public string PasswordConfirmation { get; set; }
    }
    public class UserForUpdateDto : UserForCreationDto
    {
    }

    public class BookForBulkUpdateDto : UserForUpdateDto
    {
        public int Id { get; set; }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
