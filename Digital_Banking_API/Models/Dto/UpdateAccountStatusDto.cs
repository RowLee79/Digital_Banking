using System.ComponentModel.DataAnnotations;

namespace Digital_Banking_API.Models.Dto
{
    public class UpdateAccountStatusDto
    {
        [Required]
        public bool IsActive { get; set; }
    }
}
