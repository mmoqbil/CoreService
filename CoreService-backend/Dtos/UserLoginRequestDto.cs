using System.ComponentModel.DataAnnotations;

namespace CoreService_backend.Dtos
{
    public class UserLoginRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }

    public class UserRegistrationRequestDto : UserLoginRequestDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        public ICollection<string> Roles { get; set; }
    }
}
