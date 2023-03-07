﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CoreService_Core.Model.Enum;

namespace CoreService_Core.Model.Entities;

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
    public DateTime DateTime { get; set; }
}