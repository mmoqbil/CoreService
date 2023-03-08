using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreService_backend.Models.Enum;
using Microsoft.AspNetCore.Identity;

namespace CoreService_backend.Models.Entities;

[Table("Resources")]
public class Resource
{
    [Key]
    public string Id { get; set; }

    [Required]
    [MaxLength(256)]
    public string Name { get; set; }

    [Required]
    [MaxLength(256)]
    public string UrlAdress { get; set; }

    [Required]
    [ForeignKey(nameof(IdentityUser))]
    public string UserId { get; set; }

    public virtual IdentityUser User { get; set; }

    [Required]
    public TimeSpan Refresh { get; set; }

    [Required]
    public RequestType RequestType { get; set; }

    [Required]
    public DateTime CreationTime { get; set; }
}