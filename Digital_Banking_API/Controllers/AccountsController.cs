using Digital_Banking_API.Data;
using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;
using Digital_Banking_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Digital_Banking_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly BankingContext _context;

        public AccountsController(IAccountService accountService, BankingContext context)
        {
            _accountService = accountService;
            _context = context;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountDetails(string accountNumber)
        {
            var result = await _accountService.GetAccountDetailsAsync(accountNumber);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto dto)
        {
            var result = await _accountService.CreateAccountAsync(dto);
            return CreatedAtAction(nameof(GetAccountDetails), new { accountNumber = result.AccountNumber }, result);
        }

        [HttpGet("{accountNumber}/balance")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            var balance = await _accountService.GetBalanceAsync(accountNumber);
            if (balance == null) return NotFound();
            return Ok(balance);
        }

        [HttpPut("{accountNumber}/status")]
        public async Task<IActionResult> UpdateStatus(string accountNumber, [FromBody] UpdateAccountStatusDto dto)
        {
            var updated = await _accountService.UpdateStatusAsync(accountNumber, dto.IsActive);
            if (!updated) return NotFound();
            return NoContent();
        }

        [HttpGet("{accountNumber}/limit")]
        public async Task<IActionResult> GetLimit(string accountNumber)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) return NotFound("Account not found.");
            return Ok(account.DailyLimit);
        }

        [HttpPut("{accountNumber}/limit")]
        public async Task<IActionResult> SetLimit(string accountNumber, [FromBody] decimal newLimit)
        {
            if (newLimit <= 0) return BadRequest("Limit must be greater than zero.");
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountNumber == accountNumber);
            if (account == null) return NotFound("Account not found.");

            account.DailyLimit = newLimit;
            await _context.SaveChangesAsync();
            return Ok(account.DailyLimit);
        }

    }
}
