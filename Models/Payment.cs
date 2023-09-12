
namespace CoreTravel
{
    public class Payment
    {

        [Key]
        public int? Id { get; set; }

        public int? Payment_Number { get; set; }

        public int? PaymentType_Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Payment()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
        
    }
}