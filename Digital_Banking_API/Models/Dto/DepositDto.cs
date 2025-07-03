using System.ComponentModel.DataAnnotations;

namespace Digital_Banking_API.Models.Dto
{
    public class DepositDto
    {
        [Required]
        public string AccountNumber { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Deposit amount must be greater than zero")]
        public decimal Amount { get; set; }

        public string Description { get; set; } = "Deposit";
    }
}
