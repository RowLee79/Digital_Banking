using Digital_Banking_API.Data;
using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;
using Digital_Banking_API.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Digital_Banking_API.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly BankingContext _context;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(BankingContext context, ILogger<TransactionService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Transaction> DepositAsync(TransactionDto dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == dto.AccountNumber);
            if (account == null || !account.IsActive) throw new Exception("Invalid account.");
            if (dto.Amount <= 0) throw new Exception("Invalid amount.");

            var todayTotal = await GetTotalTransactionsTodayAsync(account.Id); // or from.Id
            if (todayTotal + dto.Amount > account.DailyLimit)
                throw new Exception("Daily transaction limit exceeded.");


            account.Balance += dto.Amount;

            var transaction = new Transaction
            {
                FromAccountId = account.Id,
                Amount = dto.Amount,
                TransactionType = "Deposit",
                Description = dto.Description,
                Status = "Success",
                Timestamp = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> WithdrawAsync(TransactionDto dto)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == dto.AccountNumber);

            var fee = Math.Round(dto.Amount * 0.01m, 2);
            var totalAmount = dto.Amount + fee;


            if (account == null || !account.IsActive) throw new Exception("Invalid account.");
            if (dto.Amount <= 0) throw new Exception("Invalid amount.");

            if (account.Balance < totalAmount)
                throw new Exception("Insufficient balance including fee.");

            //  if (account.Balance < dto.Amount) throw new Exception("Insufficient balance.");

            var todayTotal = await GetTotalTransactionsTodayAsync(account.Id); // or from.Id
            if (todayTotal + dto.Amount > account.DailyLimit)
                throw new Exception("Daily transaction limit exceeded.");


            //account.Balance -= dto.Amount;

            //var transaction = new Transaction
            //{
            //    FromAccountId = account.Id,
            //    Amount = dto.Amount,
            //    TransactionType = "Withdrawal",
            //    Description = dto.Description,
            //    Status = "Success",
            //    Timestamp = DateTime.UtcNow
            //};
         

           

            account.Balance -= totalAmount;

            var transaction = new Transaction
            {
                FromAccountId = account.Id,
                Amount = dto.Amount,
                Fee = fee,
                TransactionType = "Withdrawal",
                Description = dto.Description,
                Status = "Success",
                Timestamp = DateTime.UtcNow
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;
        }

        public async Task<Transaction> TransferAsync(TransferDto dto)
        {
            var from = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == dto.FromAccount);
            var to = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == dto.ToAccount);

            var fee = Math.Round(dto.Amount * 0.02m, 2);
            var totalAmount = dto.Amount + fee;

        



            if (from == null || to == null) throw new Exception("Invalid account.");
            if (!from.IsActive || !to.IsActive) throw new Exception("One or both accounts are inactive.");
            if (dto.Amount <= 0) throw new Exception("Invalid amount.");

            if (from.Balance < totalAmount)
                throw new Exception("Insufficient balance including fee.");

            //if (from.Balance < dto.Amount) throw new Exception("Insufficient balance.");

            var todayTotal = await GetTotalTransactionsTodayAsync(from.Id); // Corrected from 'account.Id' to 'from.Id'
            if (todayTotal + dto.Amount > from.DailyLimit)
                throw new Exception("Daily transaction limit exceeded.");

            using var tx = await _context.Database.BeginTransactionAsync();

            //from.Balance -= dto.Amount;
            //to.Balance += dto.Amount;




            from.Balance -= totalAmount;
            to.Balance += dto.Amount;

            var transaction = new Transaction
            {
                FromAccountId = from.Id,
                ToAccountId = to.Id,
                Amount = dto.Amount,
                Fee = fee,
                TransactionType = "Transfer",
                Description = dto.Description,
                Status = "Success",
                Timestamp = DateTime.UtcNow
            };

            //var transaction = new Transaction
            //{
            //    FromAccountId = from.Id,
            //    ToAccountId = to.Id,
            //    Amount = dto.Amount,
            //    TransactionType = "Transfer",
            //    Description = dto.Description,
            //    Status = "Success",
            //    Timestamp = DateTime.UtcNow
            //};

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            await tx.CommitAsync();

            return transaction;
        }

        public async Task<Transaction> GetTransactionAsync(int id)
        {
            return await _context.Transactions
                .Include(t => t.FromAccount)
                .Include(t => t.ToAccount)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Transaction>> GetTransactionHistoryAsync(string accountNumber)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found.");

            return await _context.Transactions
                .Where(t => t.FromAccountId == account.Id || t.ToAccountId == account.Id)
                .OrderByDescending(t => t.Timestamp)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetStatementAsync(string accountNumber, DateTime from, DateTime to)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found.");

            return await _context.Transactions
                .Where(t =>
                    (t.FromAccountId == account.Id || t.ToAccountId == account.Id) &&
                    t.Timestamp >= from && t.Timestamp <= to)
                .OrderByDescending(t => t.Timestamp)
                .ToListAsync();
        }
        private async Task<decimal> GetTotalTransactionsTodayAsync(int accountId)
        {
            var today = DateTime.UtcNow.Date;
            return await _context.Transactions
                .Where(t => t.FromAccountId == accountId && t.Timestamp.Date == today && t.Status == "Success")
                .SumAsync(t => t.Amount);
        }
    }
}