using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddStudentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 20, nullable: false),
                    Middlename = table.Column<string>(maxLength: 20, nullable: true),
                    Lastname = table.Column<string>(maxLength: 20, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    AlternatePhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<int>(nullable: false),
                    ProfilePhotoPath = table.Column<string>(nullable: true),
                    ResidentialAddress = table.Column<string>(nullable: false),
                    ContactAddress = table.Column<string>(nullable: true),
                    AlternateEmailAddress = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true),
                    FacultyId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentAccademicInformations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfInstitution = table.Column<string>(nullable: true),
                    YearEnrolled = table.Column<string>(nullable: true),
                    YearOfGraduation = table.Column<string>(nullable: true),
                    PreviousLevel = table.Column<int>(nullable: false),
                    StudentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAccademicInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentAccademicInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<long>(nullable: false),
                    CourseId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StudentNextOfKinInformations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NextOfKinFirstname = table.Column<string>(maxLength: 20, nullable: false),
                    NextOfKinLastname = table.Column<string>(maxLength: 20, nullable: false),
                    RelationToNextOfKin = table.Column<int>(nullable: false),
                    PhoneOfNextOfKin = table.Column<string>(nullable: false),
                    EmailOfNextOfKin = table.Column<string>(nullable: false),
                    StudentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNextOfKinInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentNextOfKinInformations_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentSponsors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SponsorFirstname = table.Column<string>(maxLength: 30, nullable: false),
                    SponsorMiddlename = table.Column<string>(maxLength: 30, nullable: true),
                    SponsorLastname = table.Column<string>(maxLength: 30, nullable: false),
                    SponsorEmailAddress = table.Column<string>(nullable: false),
                    SponsorPhoneNumber = table.Column<string>(nullable: false),
                    SponsorContactAddress = table.Column<string>(nullable: false),
                    SponsorProffession = table.Column<string>(nullable: false),
                    SponsorWorkAddress = table.Column<string>(nullable: false),
                    StudentId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentSponsors_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2f256069-d17f-4f09-80c4-42b6366da629", "5bcece2f-8920-4cc6-94b5-e08977722663" });

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccademicInformations_StudentId",
                table: "StudentAccademicInformations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNextOfKinInformations_StudentId",
                table: "StudentNextOfKinInformations",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdentityUserId",
                table: "Students",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSponsors_StudentId",
                table: "StudentSponsors",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAccademicInformations");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "StudentNextOfKinInformations");

            migrationBuilder.DropTable(
                name: "StudentSponsors");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "932d8580-189e-4fa9-a395-65ed534a2060", "5a45450b-5d73-4df6-8f02-4057c05669a8" });
        }
    }
}
