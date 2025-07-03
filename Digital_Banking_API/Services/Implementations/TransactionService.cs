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
            if (account == null || !account.IsActive)
                throw new Exception("Invalid account.");

            if (dto.Amount <= 0)
                throw new Exception("Invalid amount.");

            var today = DateTime.UtcNow.Date;
            var totalToday = await _context.Transactions
                .Where(t => t.FromAccountId == account.Id && t.Timestamp.Date == today)
                .SumAsync(t => (decimal?)t.Amount) ?? 0;

 
            var fee = Math.Round(dto.Amount * 0.01m, 2);
            var finalAmount = dto.Amount - fee;
            if (finalAmount <= 0)
                throw new Exception("Amount too low after fee deduction.");


            if (totalToday + dto.Amount > account.DailyLimit)
            {
                throw new Exception($"Daily transaction limit exceeded. You can still transact ₱{account.DailyLimit - totalToday} today.");
            }

            account.Balance += finalAmount;

            var transaction = new Transaction
            {
                FromAccountId = account.Id,
                Amount = dto.Amount,
                TransactionType = "Deposit",
                Description = string.IsNullOrWhiteSpace(dto.Description)
                    ? $"Deposit (Fee: {fee})"
                    : dto.Description,
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


            var todayTotal = await GetTotalTransactionsTodayAsync(account.Id);
            if (todayTotal + dto.Amount > account.DailyLimit)
                throw new Exception("Daily transaction limit exceeded.");


            if (todayTotal + dto.Amount > account.DailyLimit)
            {
                throw new Exception($"Daily transaction limit exceeded. You can still transact ₱{account.DailyLimit - todayTotal} today.");
            }


            account.Balance -= totalAmount;

            var transaction = new Transaction
            {
                FromAccountId = account.Id,
                Amount = dto.Amount,
                Fee = fee,
                TransactionType = "Withdrawal",
                Description = dto.Description,
                Status = "Success",
                PostBalance = account.Balance,
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

            var todayTotal = await GetTotalTransactionsTodayAsync(from.Id);
            if (todayTotal + dto.Amount > from.DailyLimit)
                throw new Exception("Daily transaction limit exceeded.");

            using var tx = await _context.Database.BeginTransactionAsync();

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
                PostBalance = from.Balance,
                Timestamp = DateTime.UtcNow
            };


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
        public async Task<List<Transaction>> GetTransactionHistoryAsync(string accountNumber)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);

            if (account == null)
                throw new Exception("Account not found.");

            var transactions = await _context.Transactions
                .Where(t => t.FromAccountId == account.Id || t.ToAccountId == account.Id)
                .OrderByDescending(t => t.Timestamp)
                .Select(t => new Transaction
                {
                    Id = t.Id,
                    FromAccountId = t.FromAccountId,
                    ToAccountId = t.ToAccountId,
                    Amount = t.Amount,
                    TransactionType = t.TransactionType,
                    Description = t.Description,
                    Timestamp = t.Timestamp,
                    Status = t.Status,
                    PostBalance = t.PostBalance
                })
                .ToListAsync();

            return transactions;
        }

        public async Task<List<Transaction>> SearchTransactionsAsync(string accountNumber, decimal? amount, string description)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found.");

            var query = _context.Transactions
                .Where(t => t.FromAccountId == account.Id || t.ToAccountId == account.Id);

            if (amount.HasValue)
                query = query.Where(t => t.Amount == amount.Value);

            if (!string.IsNullOrWhiteSpace(description))
                query = query.Where(t => t.Description.Contains(description));

            return await query.OrderByDescending(t => t.Timestamp).ToListAsync();
        }
        public async Task<List<BalanceHistoryDto>> GetBalanceHistoryAsync(string accountNumber)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) throw new Exception("Account not found.");

            var transactions = await _context.Transactions
                .Where(t => t.FromAccountId == account.Id || t.ToAccountId == account.Id)
                .OrderBy(t => t.Timestamp)
                .ToListAsync();

            decimal balance = 0;
            var history = new List<BalanceHistoryDto>();

            foreach (var t in transactions)
            {
                var isOutgoing = t.FromAccountId == account.Id;
                var isIncoming = t.ToAccountId == account.Id;

                decimal effect = 0;
                if (t.TransactionType == "Deposit" && isOutgoing)
                    effect = t.Amount;
                else if (t.TransactionType == "Withdrawal" && isOutgoing)
                    effect = -t.Amount;
                else if (t.TransactionType == "Transfer")
                    effect = isOutgoing ? -t.Amount : t.Amount;

                balance += effect;

                history.Add(new BalanceHistoryDto
                {
                    Timestamp = t.Timestamp,
                    TransactionType = t.TransactionType,
                    Amount = t.Amount,
                    Description = t.Description,
                    RunningBalance = balance
                });
            }

            return history;
        }

    }
}