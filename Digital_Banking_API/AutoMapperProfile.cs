using AutoMapper;
using Digital_Banking_API.Models;
using Digital_Banking_API.Models.Dto;

namespace Digital_Banking_API
{
    public class AutoMapperProfile : Profile // Fix for CS0103: Ensure AutoMapper's Profile base class is inherited
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();

            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<CreateAccountDto, Account>();

            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}
