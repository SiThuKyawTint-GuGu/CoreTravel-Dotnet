using System;
using System.ComponentModel.DataAnnotations;
using CoreTravel.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreTravel.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int? UserId { get; set; }

        [Required]
        public string? Value { get; set; }

        public DateTime CreatedAt { get; set; }

        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        public Token()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
