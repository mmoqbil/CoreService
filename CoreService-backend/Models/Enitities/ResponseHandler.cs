﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreService_backend.Enitities;
using CoreService_backend.Models.Enum;

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
        public int StatusCode { get; set; }

        [Required]
        public ResponseStatus Status { get; set; }

        [MaxLength(100)]
        public string? ErrorMessage { get; set; }

        public int? Ping { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
