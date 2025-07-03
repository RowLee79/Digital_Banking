using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_Banking_API.Migrations
{
    public partial class addDailyLimitNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1497));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1498));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1187));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1410));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1421));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1425));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1431));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1439));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1443));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1448));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1568));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1570));
        }
    }
}
