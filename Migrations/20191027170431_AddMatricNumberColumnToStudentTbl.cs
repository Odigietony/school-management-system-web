using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddMatricNumberColumnToStudentTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MatriculationNumber",
                table: "Students",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ae0a0b7f-7ef0-41f3-993e-f5bd43e6581a", "b2674e67-ce3b-4bcf-bec3-bab3284ec169" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatriculationNumber",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04305d45-73b7-4ba5-a8ac-c1b2632c71ed", "e93deb73-ad99-4909-96f4-2b7f07c93223" });
        }
    }
}
