
namespace CoreTravel
{
    public class Booking
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        public DateTime Start_date { get; set; }

        [Required]
        public DateTime End_date { get; set; }

        public int? TicketWay_Id { get; set; }

        public int? TravelServices_Id { get; set; }

        public string? Image { get; set; }

        public int? Status_Id { get; set; }

        public string? Benefits { get; set; }

        public int? Direction_Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Booking()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        
    }
}