using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CoreService_backend.Enitities
{
    [Table("Resources")]
    public class Resource
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string IpAdress { get; set; }

        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; }


        //[Required]
        //[ForeignKey(nameof(User))]
        //public int UserId { get; set; }

        public TimeSpan Repeat { get; set; }
    }
}
