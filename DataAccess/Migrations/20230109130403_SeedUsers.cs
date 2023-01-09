using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirthDate", "CreatedAt", "Email", "IsActive", "Nickname", "PasswordHash", "PasswordSalt", "RoleId" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 9, 15, 4, 2, 872, DateTimeKind.Local).AddTicks(7604), "admin@email.com", true, "Super Admin", new byte[] { 38, 193, 252, 145, 238, 40, 69, 186, 117, 153, 128, 19, 179, 253, 59, 90, 247, 64, 1, 213, 194, 147, 157, 24, 132, 105, 205, 97, 254, 255, 180, 20, 110, 4, 24, 191, 94, 104, 181, 16, 110, 29, 242, 193, 26, 143, 77, 114, 153, 65, 120, 205, 18, 204, 84, 11, 255, 54, 205, 254, 40, 43, 77, 236 }, new byte[] { 54, 42, 212, 167, 13, 67, 124, 231, 135, 199, 225, 163, 171, 25, 230, 168, 191, 160, 225, 185, 63, 231, 0, 171, 204, 138, 86, 94, 181, 164, 70, 43, 98, 234, 253, 94, 242, 144, 220, 41, 186, 80, 38, 91, 1, 215, 163, 166, 46, 123, 236, 13, 137, 173, 148, 127, 134, 134, 56, 214, 71, 141, 189, 170, 75, 201, 49, 211, 24, 188, 94, 212, 127, 120, 55, 81, 79, 24, 13, 125, 242, 154, 28, 36, 105, 11, 195, 204, 90, 129, 191, 201, 81, 170, 226, 36, 87, 9, 7, 160, 170, 133, 239, 171, 201, 2, 193, 131, 215, 244, 0, 25, 205, 238, 239, 112, 17, 204, 9, 181, 115, 54, 82, 65, 183, 193, 190, 123 }, new Guid("00000000-0000-0000-0000-000000000001") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"));
        }
    }
}
