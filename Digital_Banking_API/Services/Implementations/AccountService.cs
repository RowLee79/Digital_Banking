using AutoMapper;
using Digital_Banking_API.Data;
using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Digital_Banking_API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly BankingContext _context;
        private readonly IMapper _mapper;

        public AccountService(BankingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AccountDto?> GetAccountDetailsAsync(string accountNumber)
        {
            var account = await _context.Accounts
                .Include(a => a.Transactions.OrderByDescending(t => t.Timestamp).Take(5))
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);

            return account == null ? null : _mapper.Map<AccountDto>(account);
        }

        public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
        {
            if (!await _context.Customers.AnyAsync(c => c.Id == dto.CustomerId))
                throw new ArgumentException("Customer does not exist.");

            var account = _mapper.Map<Account>(dto);
            account.AccountNumber = GenerateUniqueAccountNumber();
            account.CreatedDate = DateTime.UtcNow;
            account.IsActive = true;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return _mapper.Map<AccountDto>(account);
        }

        public async Task<decimal?> GetBalanceAsync(string accountNumber)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            return account?.Balance;
        }

        public async Task<bool> UpdateStatusAsync(string accountNumber, bool isActive)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) return false;

            account.IsActive = isActive;
            await _context.SaveChangesAsync();
            return true;
        }

        private string GenerateUniqueAccountNumber()
        {
            var rng = new Random();
            string accountNumber;
            do
            {
                accountNumber = rng.Next(10000000, 99999999).ToString();
            } while (_context.Accounts.Any(a => a.AccountNumber == accountNumber));
            return accountNumber;
        }
    }

}
