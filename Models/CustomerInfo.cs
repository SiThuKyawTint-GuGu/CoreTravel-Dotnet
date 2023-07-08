
namespace CoreTravel
{
    public class CustomerInfo
    {
        [Key]
        public int? Id { get; set; }

        public int?Customer_Id  { get; set; }

        public string?Location { get; set; }

        public string? Language { get; set; }

        public string? Currency { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public CustomerInfo()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}