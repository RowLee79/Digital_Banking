using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_Banking_API.Migrations
{
    public partial class AddAccountBalanceHistoryTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PostBalance",
                table: "Transactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7347));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7351));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7219));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7226));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7230));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7234));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7287));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7291));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7303));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 11, 27, 36, 392, DateTimeKind.Utc).AddTicks(7433));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostBalance",
                table: "Transactions");

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
    }
}
