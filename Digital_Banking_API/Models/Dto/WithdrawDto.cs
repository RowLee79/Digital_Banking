using System.ComponentModel.DataAnnotations;

namespace Digital_Banking_API.Models.Dto
{
    public class WithdrawDto
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
