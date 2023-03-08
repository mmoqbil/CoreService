using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreService_backend.Models.Enum;

namespace CoreService_backend.Models.Entities;

[Table("Response")]
public class ResponseHandler
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Resource))]
    public string ResourceId { get; set; }

    public int? StatusCode { get; set; }

    [Required]
    public ResponseStatus ResponseStatus { get; set; }

    [MaxLength(100)]
    public string? ErrorMessage { get; set; }

    public int? Ping { get; set; }

    [Required]
    // TODO: Change name to CreationDate
    public DateTime DateTime { get; set; }
}