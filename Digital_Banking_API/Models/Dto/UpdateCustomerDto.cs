using System.ComponentModel.DataAnnotations;

namespace Digital_Banking_API.Models.Dto
{
    public class UpdateCustomerDto
    {
        [Required] public string FirstName { get; set; } = string.Empty;
        [Required] public string LastName { get; set; } = string.Empty;
        [EmailAddress] public string Email { get; set; } = string.Empty;
        [Phone] public string Phone { get; set; } = string.Empty;
    }
}
