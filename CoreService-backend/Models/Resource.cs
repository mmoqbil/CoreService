using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreService_backend.Models
{
    public class Resource
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [Required]
        [MaxLength(256)]
        public string IpAdress { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public Resource(string name, string ipAdress, Guid userId)
        {
            Name = name;
            IpAdress = ipAdress;
            UserId = userId;
        }
    }
}
