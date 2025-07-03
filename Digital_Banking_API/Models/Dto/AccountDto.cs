namespace Digital_Banking_API.Models.Dto
{
    public class AccountDto
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string AccountType { get; set; } = string.Empty;
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<TransactionDto> Transactions { get; set; } = new();
    }
}
