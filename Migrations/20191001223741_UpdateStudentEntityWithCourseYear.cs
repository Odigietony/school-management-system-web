using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class UpdateStudentEntityWithCourseYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CourseYearId",
                table: "Students",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "04305d45-73b7-4ba5-a8ac-c1b2632c71ed", "e93deb73-ad99-4909-96f4-2b7f07c93223" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseYearId",
                table: "Students",
                column: "CourseYearId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_CourseYears_CourseYearId",
                table: "Students",
                column: "CourseYearId",
                principalTable: "CourseYears",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_CourseYears_CourseYearId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseYearId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseYearId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3dd04987-629c-4c62-95a5-f7b3498d0a0c", "b0ed06ee-7045-4674-9306-ef7c36f1c658" });
        }
    }
}
