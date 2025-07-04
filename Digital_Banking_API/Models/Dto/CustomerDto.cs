﻿namespace Digital_Banking_API.Models.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<AccountDto> Accounts { get; set; } = new();
    }
}
