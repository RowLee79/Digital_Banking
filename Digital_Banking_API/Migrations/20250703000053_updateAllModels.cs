using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_Banking_API.Migrations
{
    public partial class updateAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.AlterColumn<int>(
                name: "ToAccountId",
                table: "Transactions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedDate", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4048), "user1@mail.com", "First1", "Last1", "09170000001" },
                    { 2, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4086), "user2@mail.com", "First2", "Last2", "09170000002" },
                    { 3, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4091), "user3@mail.com", "First3", "Last3", "09170000003" },
                    { 4, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4094), "user4@mail.com", "First4", "Last4", "09170000004" },
                    { 5, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4098), "user5@mail.com", "First5", "Last5", "09170000005" },
                    { 6, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4104), "user6@mail.com", "First6", "Last6", "09170000006" },
                    { 7, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4108), "user7@mail.com", "First7", "Last7", "09170000007" },
                    { 8, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4112), "user8@mail.com", "First8", "Last8", "09170000008" },
                    { 9, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4116), "user9@mail.com", "First9", "Last9", "09170000009" },
                    { 10, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4121), "user10@mail.com", "First10", "Last10", "09170000010" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "Balance", "CreatedDate", "CustomerId", "IsActive" },
                values: new object[] { 1, "10000001", "Checking", 1000.00m, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4177), 1, true });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "Balance", "CreatedDate", "CustomerId", "IsActive" },
                values: new object[] { 2, "10000002", "Savings", 2500.00m, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4179), 2, true });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AccountType", "Balance", "CreatedDate", "CustomerId", "IsActive" },
                values: new object[] { 3, "10000003", "Checking", 500.00m, new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4181), 3, false });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Description", "FromAccountId", "Status", "Timestamp", "ToAccountId", "TransactionType" },
                values: new object[] { 1, 500.00m, "Initial deposit", 1, "Completed", new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4251), null, "Deposit" });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Description", "FromAccountId", "Status", "Timestamp", "ToAccountId", "TransactionType" },
                values: new object[] { 2, 100.00m, "Test transfer", 2, "Completed", new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4253), 3, "Transfer" });

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts");

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "ToAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                table: "Accounts",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
