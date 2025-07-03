namespace Digital_Banking_API.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int FromAccountId { get; set; }
        public int? ToAccountId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; } = "Deposit"; // Deposit, Withdrawal, Transfer
        public string Description { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Completed";
        public decimal PostBalance { get; set; }
        public Account FromAccount { get; set; } = null!;
        public Account? ToAccount { get; set; }
        public decimal Fee { get; set; } // Add this

    }
}