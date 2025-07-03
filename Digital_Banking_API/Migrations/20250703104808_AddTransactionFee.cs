using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_Banking_API.Migrations
{
    public partial class AddTransactionFee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8051));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8059));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8076));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8087));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8223));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 10, 48, 7, 996, DateTimeKind.Utc).AddTicks(8225));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "Transactions");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5679));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5681));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5682));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5560));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5600));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5605));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5609));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5613));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5631));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5636));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 10, 33, 51, 175, DateTimeKind.Utc).AddTicks(5749));
        }
    }
}
