namespace Digital_Banking_API.Models.Dto
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
        public string AccountNumber { get; set; } // Added property to fix CS0117  
        public decimal Fee { get; set; } // Add this

    }
}
