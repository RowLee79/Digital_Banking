using System.ComponentModel.DataAnnotations;

namespace Digital_Banking_API.Models.Dto
{
    public class TransferDto
    {
        [Required]
        public string FromAccount { get; set; } = string.Empty;

        [Required]
        public string ToAccount { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "Transfer amount must be greater than zero")]
        public decimal Amount { get; set; }

        public string Description { get; set; } = "Transfer";
    }
}
