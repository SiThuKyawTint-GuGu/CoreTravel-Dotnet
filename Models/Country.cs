

namespace CoreTravel.Models
{
    public class Country
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Country(){
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        
    }
}