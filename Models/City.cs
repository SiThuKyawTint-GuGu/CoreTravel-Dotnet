
namespace CoreTravel
{
    public class City
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public int? Country_Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public City()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}