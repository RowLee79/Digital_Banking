using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Digital_Banking_API.Migrations
{
    public partial class addDailyLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DailyLimit",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DailyLimit" },
                values: new object[] { new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1497), 10000m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "DailyLimit" },
                values: new object[] { new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1498), 10000m });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "DailyLimit" },
                values: new object[] { new DateTime(2025, 7, 3, 10, 31, 16, 163, DateTimeKind.Utc).AddTicks(1500), 10000m });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DailyLimit",
                table: "Accounts");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4181));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4048));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4086));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4098));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4104));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4108));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4112));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4121));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4251));

            migrationBuilder.UpdateData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 7, 3, 0, 0, 53, 558, DateTimeKind.Utc).AddTicks(4253));
        }
    }
}
