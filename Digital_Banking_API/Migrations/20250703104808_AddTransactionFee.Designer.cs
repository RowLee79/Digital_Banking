﻿// <auto-generated />
using System;
using Digital_Banking_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Digital_Banking_API.Migrations
{
    [DbContext(typeof(BankingContext))]
    [Migration("20250703104808_AddTransactionFee")]
    partial class AddTransactionFee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Digital_Banking_API.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AccountType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("DailyLimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber")
                        .IsUnique();

                    b.HasIndex("CustomerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountNumber = "10000001",
                            AccountType = "Checking",
                            Balance = 1000.00m,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8148),
                            CustomerId = 1,
                            DailyLimit = 10000m,
                            IsActive = true
                        },
                        new
                        {
                            Id = 2,
                            AccountNumber = "10000002",
                            AccountType = "Savings",
                            Balance = 2500.00m,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8150),
                            CustomerId = 2,
                            DailyLimit = 10000m,
                            IsActive = true
                        },
                        new
                        {
                            Id = 3,
                            AccountNumber = "10000003",
                            AccountType = "Checking",
                            Balance = 500.00m,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8152),
                            CustomerId = 3,
                            DailyLimit = 10000m,
                            IsActive = false
                        });
                });

            modelBuilder.Entity("Digital_Banking_API.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8051),
                            Email = "user1@mail.com",
                            FirstName = "First1",
                            LastName = "Last1",
                            Phone = "09170000001"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8059),
                            Email = "user2@mail.com",
                            FirstName = "First2",
                            LastName = "Last2",
                            Phone = "09170000002"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8063),
                            Email = "user3@mail.com",
                            FirstName = "First3",
                            LastName = "Last3",
                            Phone = "09170000003"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8067),
                            Email = "user4@mail.com",
                            FirstName = "First4",
                            LastName = "Last4",
                            Phone = "09170000004"
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8071),
                            Email = "user5@mail.com",
                            FirstName = "First5",
                            LastName = "Last5",
                            Phone = "09170000005"
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8076),
                            Email = "user6@mail.com",
                            FirstName = "First6",
                            LastName = "Last6",
                            Phone = "09170000006"
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8079),
                            Email = "user7@mail.com",
                            FirstName = "First7",
                            LastName = "Last7",
                            Phone = "09170000007"
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8083),
                            Email = "user8@mail.com",
                            FirstName = "First8",
                            LastName = "Last8",
                            Phone = "09170000008"
                        },
                        new
                        {
                            Id = 9,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8087),
                            Email = "user9@mail.com",
                            FirstName = "First9",
                            LastName = "Last9",
                            Phone = "09170000009"
                        },
                        new
                        {
                            Id = 10,
                            CreatedDate = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8116),
                            Email = "user10@mail.com",
                            FirstName = "First10",
                            LastName = "Last10",
                            Phone = "09170000010"
                        });
                });

            modelBuilder.Entity("Digital_Banking_API.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Fee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToAccountId")
                        .HasColumnType("int");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 500.00m,
                            Description = "Initial deposit",
                            Fee = 0m,
                            FromAccountId = 1,
                            Status = "Completed",
                            Timestamp = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8223),
                            TransactionType = "Deposit"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 100.00m,
                            Description = "Test transfer",
                            Fee = 0m,
                            FromAccountId = 2,
                            Status = "Completed",
                            Timestamp = new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8225),
                            ToAccountId = 3,
                            TransactionType = "Transfer"
                        });
                });

            modelBuilder.Entity("Digital_Banking_API.Models.Account", b =>
                {
                    b.HasOne("Digital_Banking_API.Models.Customer", "Customer")
                        .WithMany("Accounts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Digital_Banking_API.Models.Transaction", b =>
                {
                    b.HasOne("Digital_Banking_API.Models.Account", "FromAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Digital_Banking_API.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("Digital_Banking_API.Models.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Digital_Banking_API.Models.Customer", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
