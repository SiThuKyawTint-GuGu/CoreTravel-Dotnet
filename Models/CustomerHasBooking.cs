

namespace CoreTravel
{
    public class CustomerHasBooking
    {

        [Key]
        public int? Id { get; set; }

        public int? Customer_Id { get; set; }

        public int? Booking_Id { get; set; }

        public int? Paymentinfo_Id { get; set; }

        [Required]
        public DateTime Date_of_booking { get; set; }

        public int? Total_amount { get; set; }

        public int? BookingStatus_Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public CustomerHasBooking()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        
    }
}