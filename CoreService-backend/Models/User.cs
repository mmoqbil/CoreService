using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreService_backend.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
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

        public User(Guid Id, string email, string name, string password, string passwordConfirmation)
        {
            this.Id = Id;
            Email = email;
            Name = name;
            Password = password;
            PasswordConfirmation = passwordConfirmation;
        }
    }
}
