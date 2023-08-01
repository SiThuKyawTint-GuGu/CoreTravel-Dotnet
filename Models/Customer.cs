namespace CoreTravel.Models
{
    public class Customer
    {
        [Key]
        public int? Id { get; set; }

        public string? Customer_Name { get; set; }

        [Required(ErrorMessage = "Email is require!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is require!")]
        public string? Password { get; set; }

        public int? Country_Id { get; set; }

        public int? Language_Id { get; set; }

        public int? Phone { get; set; }

        public int? Level_Id { get; set; }

        public int? Unicode { get; set; }

        public string? Image { get; set; }

        public string? Address { get; set; }

        public string? Gender { get; set; }

        public string? Birth { get; set; }

        public DateTime? Last_Login { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Customer()
        {
            Last_Login = DateTime.UtcNow;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}