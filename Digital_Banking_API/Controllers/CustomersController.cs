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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerWithAccounts(int id)
        {
            var customer = await _customerService.GetCustomerWithAccountsAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            var created = await _customerService.CreateCustomerAsync(dto);
            return CreatedAtAction(nameof(GetCustomerWithAccounts), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] UpdateCustomerDto dto)
        {
            var updated = await _customerService.UpdateCustomerAsync(id, dto);
            if (!updated) return NotFound();
            return NoContent();
        }
    }

}
