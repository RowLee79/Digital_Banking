using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;

namespace Digital_Banking_API.Services
{
    public interface IAccountService
    {
        Task<AccountDto?> GetAccountDetailsAsync(string accountNumber);
        Task<AccountDto> CreateAccountAsync(CreateAccountDto dto);
        Task<decimal?> GetBalanceAsync(string accountNumber);
        Task<bool> UpdateStatusAsync(string accountNumber, bool isActive);
    }
}
