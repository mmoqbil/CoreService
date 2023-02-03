using System.ComponentModel.DataAnnotations;

namespace CoreService_backend.Dtos
{
    public class UserForCreationDto
    {
        [Required]
        [MaxLength(512)]
        public string Email { get; set; }
        [Required]
        [MaxLength(512)]
        public string Name { get; set; }
        [Required]
        [MaxLength(512)]
        public string Password { get; set; }
        [Required]
        [MaxLength(512)]
        public string PasswordConfirmation { get; set; }
    }
    public class UserForUpdateDto : UserForCreationDto
    {
    }

    public class BookForBulkUpdateDto : UserForUpdateDto
    {
        public Guid Id { get; set; }
    }
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
