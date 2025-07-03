namespace Digital_Banking_API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public string AccountType { get; set; } = "Checking"; // or "Savings"
        public decimal Balance { get; set; } = 0.00m;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public decimal DailyLimit { get; set; } = 10000m; // Default daily limit

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
public enum AccountType
{
    Checking,
    Savings
}
