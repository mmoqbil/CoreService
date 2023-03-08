using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreService_Core.Model.Enum;

namespace CoreService_Core.Model.Dto;

public class ResourceDto
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

    [Required]
    public TimeSpan Refresh { get; set; }

    [Required]
    public RequestType RequestType { get; set; }

    [Required]
    public TimeSpan TimeLeft { get; set; }

}