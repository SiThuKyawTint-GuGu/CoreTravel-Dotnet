
namespace CoreTravel
{
    public class Transaction
    {

        [Key]
        public int? Id { get; set; }

        public int? Transaction_Number { get; set; }

        public int? Payment_Id { get; set; }

        public int? Amount { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Transaction()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }


    }
}