using Digital_Banking_API.Models.Dto;

namespace Digital_Banking_API.Services
{
    public interface ICustomerService
    {
        Task<CustomerDto?> GetCustomerWithAccountsAsync(int id);
        Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto dto);
        Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto dto);
    }
}
