using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;

namespace Digital_Banking_API.Services
{

    public interface ITransactionService
    {
        Task<Transaction> DepositAsync(TransactionDto dto);
        Task<Transaction> WithdrawAsync(TransactionDto dto);
        Task<Transaction> TransferAsync(TransferDto dto);
        Task<Transaction> GetTransactionAsync(int id);
        Task<List<Transaction>> GetTransactionHistoryAsync(string accountNumber); // Add this method
        Task<List<Transaction>> GetStatementAsync(string accountNumber, DateTime from, DateTime to);
        Task<List<Transaction>> SearchTransactionsAsync(string accountNumber, decimal? amount, string description);
        Task<List<BalanceHistoryDto>> GetBalanceHistoryAsync(string accountNumber);

    }

}
