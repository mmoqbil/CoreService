using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreService_backend.Enitities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string Email { get; set; }

        [Required]
        [MaxLength(512)]
        public string Name { get; set; }

        [Required]
        [MaxLength(512)]
        public string Password { get; set; }

        public List<Resource> Resources { get; set; }

        //Czy podczas tworzenia Resourca należy dodać do odpowiedniego obiektu User, nowo utworzony Resource?
    }
}
