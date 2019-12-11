using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddSchoolYearAndSemesterModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "SchoolSemesterId",
                table: "Courses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "SchoolSemesters",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfSemester = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Endate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolSemesters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYears",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfSeason = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYears", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_SchoolSemesterId",
                table: "Courses",
                column: "SchoolSemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_SchoolSemesters_SchoolSemesterId",
                table: "Courses",
                column: "SchoolSemesterId",
                principalTable: "SchoolSemesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_SchoolSemesters_SchoolSemesterId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "SchoolSemesters");

            migrationBuilder.DropTable(
                name: "SchoolYears");

            migrationBuilder.DropIndex(
                name: "IX_Courses_SchoolSemesterId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SchoolSemesterId",
                table: "Courses");
        }
    }
}
