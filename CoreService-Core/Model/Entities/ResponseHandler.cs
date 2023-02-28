using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CoreService_Core.Model.Entities
{
    public class ResponseHandler
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Resource))]
        public string ResourceId { get; set; }

        [Required]
        public string ResponseStatus { get; set; }

        [MaxLength(100)]
        public string ErrorMessage { get; set; }

        public int Ping { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
