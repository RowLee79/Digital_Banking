using AutoMapper;
using Digital_Banking_API.Data;
using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace Digital_Banking_API.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly BankingContext _context;
        private readonly IMapper _mapper;

        public CustomerService(BankingContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerDto?> GetCustomerWithAccountsAsync(int id)
        {
            var customer = await _context.Customers
                .Include(c => c.Accounts)
                .FirstOrDefaultAsync(c => c.Id == id);

            return customer == null ? null : _mapper.Map<CustomerDto>(customer);
        }

        public async Task<CustomerDto> CreateCustomerAsync(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            customer.CreatedDate = DateTime.UtcNow;

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<bool> UpdateCustomerAsync(int id, UpdateCustomerDto dto)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return false;

            _mapper.Map(dto, customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
