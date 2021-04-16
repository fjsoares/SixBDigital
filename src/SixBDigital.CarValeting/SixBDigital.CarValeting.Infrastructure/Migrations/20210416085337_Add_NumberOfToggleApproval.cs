using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SixBDigital.CarValeting.Infrastructure.Migrations
{
    public partial class Add_NumberOfToggleApproval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfToggleApproval",
                table: "Bookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 16, 8, 53, 36, 932, DateTimeKind.Utc).AddTicks(788), "LMVQs6OWYvF4CUH/N9ZRSTNd72Uj0u8SAaTEJTRIlLPTPdJ1oIjlFDwB90LOzV1TP7r1wOj3l1mwtjj7HfkR1w==", "100000.lZqeS04rrHxgL2T0oHR9s+1+Hy2NeWauqo5W8pnayK9lkA==", new DateTime(2021, 4, 16, 8, 53, 36, 932, DateTimeKind.Utc).AddTicks(788) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfToggleApproval",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Password", "Salt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 4, 15, 21, 44, 41, 228, DateTimeKind.Utc).AddTicks(6473), "8AwqGZ54BuaPUVXPLnBP//yVwCIjRBucXwW+jC2TCAG+qjfUCGntOH5uSeF6YcTfNDoAHLeEA/MuYmTjSVZJ3A==", "100000.bdTW4L9WQxTfQPTNSFrERXidO/gmO+dJoCi736xsrxIr0w==", new DateTime(2021, 4, 15, 21, 44, 41, 228, DateTimeKind.Utc).AddTicks(6473) });
        }
    }
}
