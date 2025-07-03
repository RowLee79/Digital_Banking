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

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
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
    }
}
