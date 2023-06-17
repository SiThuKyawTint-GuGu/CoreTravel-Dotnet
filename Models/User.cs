using System;
namespace CoreTravel.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Name Field is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Name Field is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Password Field is required")]
        public string? Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public User()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

