using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreService_backend.Enitities;

namespace CoreService_backend.Models.Enitities
{
    [Table("Response")]
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
