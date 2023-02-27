using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreService_backend.Models.Dtos
{
    public class ResourceDto
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string IpAdress { get; set; }

        [Required]
        public int RepeatAfterSeconds { get; set; }
    }

    public class ResourceUpdateDto : ResourceDto
    {
        [Required]
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public string UserId { get; set; }
    }
}
