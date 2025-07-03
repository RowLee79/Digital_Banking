using Digital_Banking_API.Models.Dto;
using Digital_Banking_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Digital_Banking_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositDto dto)
        {
            // Fix: Map DepositDto to TransactionDto before calling the service
            var transactionDto = new TransactionDto
            {
                AccountNumber = dto.AccountNumber,
                Amount = dto.Amount,
                Description = dto.Description
            };

            var result = await _transactionService.DepositAsync(transactionDto);
            return Ok(result);
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawDto dto)
        {
            // Fix: Map WithdrawDto to TransactionDto before calling the service
            var transactionDto = new TransactionDto
            {
                AccountNumber = dto.AccountNumber,
                Amount = dto.Amount,
                Description = dto.Description
            };

            var result = await _transactionService.WithdrawAsync(transactionDto);
            if (result == null || result.Status != "Success")
                return BadRequest("Transaction failed.");
            return Ok(result);
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer([FromBody] TransferDto dto)
        {
            var result = await _transactionService.TransferAsync(dto);
            if (result == null || result.Status != "Success")
                return BadRequest("Transaction failed.");
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var txn = await _transactionService.GetTransactionAsync(id);
            if (txn == null) return NotFound();
            return Ok(txn);
        }

        [HttpGet("/api/accounts/{accountNumber}/transactions")]
        public async Task<IActionResult> GetTransactionHistory(string accountNumber)
        {
            var history = await _transactionService.GetTransactionHistoryAsync(accountNumber);
            return Ok(history);
        }
    }
}
