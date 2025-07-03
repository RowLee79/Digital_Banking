namespace Digital_Banking_API.Models.Dto
{
    // Models/Dto/BalanceHistoryDto.cs
    public class BalanceHistoryDto
    {
        public DateTime Timestamp { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public decimal RunningBalance { get; set; }

        // Add this property to fix the error  
        public decimal Balance => RunningBalance;
    }

}
