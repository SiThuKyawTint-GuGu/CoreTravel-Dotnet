
namespace CoreTravel
{
    public class PaymentInfo
    {

        [Key]
        public int? Id { get; set; }

        public int? Customer_Id { get; set; }

        public int? Country_Id { get; set; }

        public int? TripPurpose_Id { get; set; }

        public int? Transaction_Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public PaymentInfo()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }


    }
}