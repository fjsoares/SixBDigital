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
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Password", "UpdatedAt", "UserName" },
                values: new object[] { 1, new DateTime(2021, 4, 15, 13, 7, 22, 936, DateTimeKind.Utc).AddTicks(6939), "$argon2id$v=19$m=65536,t=3,p=1$d0AbHWlRy2kl0qGAU9StQw$BJxxB7TFn/dn1Y1C3fwT/kiWUGoj9EOicGL+Ue6hL7Y", new DateTime(2021, 4, 15, 13, 7, 22, 936, DateTimeKind.Utc).AddTicks(6939), "admin" });
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
