using System.ComponentModel.DataAnnotations;

namespace Digital_Banking_API.Models.Dto
{
    public class CreateAccountDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [RegularExpression("Checking|Savings")]
        public string AccountType { get; set; } = "Checking";
    }
}
