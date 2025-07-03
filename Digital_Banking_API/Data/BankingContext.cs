using Digital_Banking_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Digital_Banking_API.Data
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Accounts)
                .WithOne(a => a.Customer)
                .HasForeignKey(a => a.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasIndex(a => a.AccountNumber)
                .IsUnique();

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.FromAccount)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany()
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .Property(a => a.Balance)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Transaction>()
                .Property(t => t.Amount)
                .HasColumnType("decimal(18,2)");

            // SQL Seed via HasData
            modelBuilder.Entity<Customer>().HasData(
                Enumerable.Range(1, 10).Select(i => new Customer
                {
                    Id = i,
                    FirstName = $"First{i}",
                    LastName = $"Last{i}",
                    Email = $"user{i}@mail.com",
                    Phone = $"0917{i:D7}",
                    CreatedDate = DateTime.UtcNow
                })
            );

            modelBuilder.Entity<Account>().HasData(
                new Account { Id = 1, CustomerId = 1, AccountNumber = "10000001", AccountType = "Checking", Balance = 1000.00m, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Account { Id = 2, CustomerId = 2, AccountNumber = "10000002", AccountType = "Savings", Balance = 2500.00m, IsActive = true, CreatedDate = DateTime.UtcNow },
                new Account { Id = 3, CustomerId = 3, AccountNumber = "10000003", AccountType = "Checking", Balance = 500.00m, IsActive = false, CreatedDate = DateTime.UtcNow }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    FromAccountId = 1,
                    ToAccountId = null,
                    Amount = 500.00m,
                    TransactionType = "Deposit",
                    Description = "Initial deposit",
                    Timestamp = DateTime.UtcNow,
                    Status = "Completed"
                },
                new Transaction
                {
                    Id = 2,
                    FromAccountId = 2,
                    ToAccountId = 3,
                    Amount = 100.00m,
                    TransactionType = "Transfer",
                    Description = "Test transfer",
                    Timestamp = DateTime.UtcNow,
                    Status = "Completed"
                }
            );
        }
    }
}