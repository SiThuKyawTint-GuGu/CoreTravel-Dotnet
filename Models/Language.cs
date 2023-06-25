
namespace CoreTravel
{
    public class Language
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Language()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}