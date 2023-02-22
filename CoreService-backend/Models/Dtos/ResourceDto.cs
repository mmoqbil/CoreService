using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreService_backend.Models.Dtos
{
    public class ResourceDto
    {
    }

    public class ResourceUpdateDto
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string IpAdress { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public TimeSpan Repeat { get; set; }
    }
}
