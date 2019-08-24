using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class SeedUserAndAdminData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "aeec0491-041c-4f84-bc97-3b774d6424c3", "superadmin@gmail.com", false, false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN", "SuperAdmin", null, false, "ccb5aaa0-0716-4cc6-bd96-23bf2fa1dcaf", false, "SuperAdmin" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Firstname", "IdentityUserId", "ImagePath", "Lastname" },
                values: new object[] { 1L, "Anthony", "1", null, "Russo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");
        }
    }
}
