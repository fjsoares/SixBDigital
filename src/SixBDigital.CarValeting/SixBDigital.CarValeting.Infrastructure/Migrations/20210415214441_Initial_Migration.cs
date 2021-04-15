using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SixBDigital.CarValeting.Infrastructure.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    BookingDateTime = table.Column<DateTime>(nullable: false),
                    Flexibility = table.Column<int>(nullable: false),
                    VehicleSize = table.Column<int>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Approved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Salt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "Salt", "UpdatedAt", "UserName" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 21, 44, 41, 228, DateTimeKind.Utc).AddTicks(6473), "8AwqGZ54BuaPUVXPLnBP//yVwCIjRBucXwW+jC2TCAG+qjfUCGntOH5uSeF6YcTfNDoAHLeEA/MuYmTjSVZJ3A==", "100000.bdTW4L9WQxTfQPTNSFrERXidO/gmO+dJoCi736xsrxIr0w==", new DateTime(2021, 4, 15, 21, 44, 41, 228, DateTimeKind.Utc).AddTicks(6473), "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
