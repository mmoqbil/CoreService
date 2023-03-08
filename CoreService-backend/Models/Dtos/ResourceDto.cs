using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreService_backend.Models.Enum;

namespace CoreService_backend.Models.Dtos;

public class ResourceCreateDto
{
    [Required]
    [MaxLength(256)]
    public string Name { get; set; }

    [Required]
    [MaxLength(256)]
    public string UrlAdress { get; set; }

    [Required]
    public int RefreshInSeconds { get; set; }

    [Required]
    public RequestType RequestType { get; set; }
}

public class ResourceDto : ResourceCreateDto
{
    public string Id { get; set; }
}

public class ResourceWithTimeDto : ResourceDto
{
    public DateTime CreationTime { get; set; }
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