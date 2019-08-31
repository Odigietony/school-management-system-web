using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class TeachersCountriesRefereesStatesAndSeedCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Referees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(maxLength: 20, nullable: false),
                    Designation = table.Column<string>(maxLength: 20, nullable: false),
                    Organisation = table.Column<string>(maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherHighestDegrees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfInstitution = table.Column<string>(nullable: true),
                    YearEnrolled = table.Column<string>(nullable: true),
                    YearOfGraduation = table.Column<string>(nullable: true),
                    DegreeAttained = table.Column<string>(nullable: true),
                    CGPA = table.Column<double>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherHighestDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherOtherDegrees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameOfInstitution = table.Column<string>(nullable: true),
                    YearOfEnrollement = table.Column<string>(nullable: true),
                    YearOfGraduation = table.Column<string>(nullable: true),
                    DegreeAttained = table.Column<string>(nullable: true),
                    CGPA = table.Column<double>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOtherDegrees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(maxLength: 20, nullable: false),
                    Middlename = table.Column<string>(maxLength: 20, nullable: false),
                    Lastname = table.Column<string>(maxLength: 20, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    ProfilePhotoPath = table.Column<string>(nullable: true),
                    IdentityUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StateName = table.Column<string>(nullable: true),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherContactInformations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(maxLength: 100, nullable: false),
                    Address2 = table.Column<string>(maxLength: 100, nullable: true),
                    ZipCode = table.Column<int>(maxLength: 6, nullable: false),
                    HomePhone = table.Column<string>(nullable: false),
                    MobilePhone = table.Column<string>(nullable: true),
                    AlternateEmailAddress = table.Column<string>(nullable: true),
                    NextOfKinFirstname = table.Column<string>(maxLength: 20, nullable: false),
                    NextOfKinLastname = table.Column<string>(maxLength: 20, nullable: false),
                    RelationToNextOfKin = table.Column<int>(nullable: false),
                    PhoneOfNextOfKin = table.Column<string>(nullable: false),
                    EmailOfNextOfKin = table.Column<string>(nullable: false),
                    TeacherId = table.Column<long>(nullable: false),
                    CountryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherContactInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherContactInformations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherContactInformations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeachersProffesionalInformations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    YearsOfExperience = table.Column<int>(nullable: false),
                    FormerPlaceOfEmployment = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    YearOfEmployement = table.Column<string>(nullable: true),
                    YearOfDeparture = table.Column<string>(nullable: true),
                    TeacherRegistrationNumber = table.Column<string>(nullable: true),
                    TeacherId = table.Column<long>(nullable: false),
                    RefereeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersProffesionalInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersProffesionalInformations_Referees_RefereeId",
                        column: x => x.RefereeId,
                        principalTable: "Referees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeachersProffesionalInformations_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCertificates",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CertificateTitle = table.Column<string>(nullable: true),
                    CertificateImagePath = table.Column<string>(nullable: true),
                    TeacherId = table.Column<long>(nullable: false),
                    TeachersProffesionalInformationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherCertificates_TeachersProffesionalInformations_TeachersProffesionalInformationId",
                        column: x => x.TeachersProffesionalInformationId,
                        principalTable: "TeachersProffesionalInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5b238292-943c-4f67-bfaa-5afe5fcdbe5f", "5a9da243-688f-4702-8a52-c3d065004ab9" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 72L, "Jamaica" },
                    { 71L, "Italy" },
                    { 70L, "Israel" },
                    { 69L, "Ireland" },
                    { 68L, "Iraq" },
                    { 67L, "Iran" },
                    { 66L, "Indonesia" },
                    { 65L, "India" },
                    { 64L, "Iceland" },
                    { 63L, "Hungary" },
                    { 62L, "Honduras" },
                    { 61L, "Haiti" },
                    { 60L, "Guinea-Bissau" },
                    { 59L, "Guinea" },
                    { 58L, "Greece" },
                    { 57L, "Ghana" },
                    { 56L, "Germany" },
                    { 55L, "Georgia" },
                    { 54L, "Gambia" },
                    { 53L, "Gabon" },
                    { 52L, "France" },
                    { 73L, "Japan" },
                    { 74L, "Jordan" },
                    { 75L, "Kazakhstan" },
                    { 76L, "Kenya" },
                    { 98L, "North Korea" },
                    { 97L, "Nigeria" },
                    { 96L, "Niger" },
                    { 95L, "Nicaragua" },
                    { 94L, "New Zealand" },
                    { 93L, "Netherlands" },
                    { 92L, "Nepal" },
                    { 91L, "Namibia" },
                    { 90L, "Myanmar (formerly Burma)" },
                    { 89L, "Mozambique" },
                    { 51L, "Finland" },
                    { 88L, "Morocco" },
                    { 86L, "Mauritius" },
                    { 85L, "Mauritania" },
                    { 84L, "Mali" },
                    { 83L, "Malaysia" },
                    { 82L, "Malawi" },
                    { 81L, "Madagascar" },
                    { 80L, "Lithuania" },
                    { 79L, "Libya" },
                    { 78L, "Liberia" },
                    { 77L, "Kuwait" },
                    { 87L, "Mexico" },
                    { 99L, "Norway" },
                    { 50L, "Fiji" },
                    { 48L, "Equatorial Guinea" },
                    { 21L, "Bosnia and Herzegovina" },
                    { 20L, "Bolivia" },
                    { 19L, "Benin" },
                    { 18L, "Belize" },
                    { 17L, "Belgium" },
                    { 16L, "Belarus" },
                    { 15L, "Barbados" },
                    { 14L, "Bangladesh" },
                    { 13L, "Bahrain" },
                    { 12L, "Bahamas" },
                    { 11L, "Azerbaijan" },
                    { 10L, "Austria" },
                    { 9L, "Australia" },
                    { 8L, "Armenia" },
                    { 7L, "Argentina" },
                    { 6L, "Antigua and Barbuda" },
                    { 5L, "Angola" },
                    { 4L, "Andorra" },
                    { 3L, "Algeria" },
                    { 2L, "Albania" },
                    { 1L, "Afghanistan" },
                    { 22L, "Botswana" },
                    { 23L, "Brazil" },
                    { 24L, "Bulgaria" },
                    { 25L, "Burkina Faso" },
                    { 47L, "El Salvador" },
                    { 46L, "Egypt" },
                    { 45L, "Ecuador" },
                    { 44L, "Dominican Republic" },
                    { 43L, "Denmark" },
                    { 42L, "Democratic Republic of the Congo" },
                    { 41L, "Czechia (Czech Republic)" },
                    { 40L, "Cyprus" },
                    { 39L, "Cuba" },
                    { 38L, "Croatia" },
                    { 49L, "Ethiopia" },
                    { 37L, "Costa Rica" },
                    { 35L, "Colombia" },
                    { 34L, "China" },
                    { 33L, "Chile" },
                    { 32L, "Chad" },
                    { 31L, "Central African Republic" },
                    { 30L, "Canada" },
                    { 29L, "Cameroon" },
                    { 28L, "Cambodia" },
                    { 27L, "Côte d'Ivoire" },
                    { 26L, "Burundi" },
                    { 36L, "Congo (Congo-Brazzaville)" },
                    { 100L, "Oman" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCertificates_TeachersProffesionalInformationId",
                table: "TeacherCertificates",
                column: "TeachersProffesionalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherContactInformations_CountryId",
                table: "TeacherContactInformations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherContactInformations_TeacherId",
                table: "TeacherContactInformations",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IdentityUserId",
                table: "Teachers",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersProffesionalInformations_RefereeId",
                table: "TeachersProffesionalInformations",
                column: "RefereeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersProffesionalInformations_TeacherId",
                table: "TeachersProffesionalInformations",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "TeacherCertificates");

            migrationBuilder.DropTable(
                name: "TeacherContactInformations");

            migrationBuilder.DropTable(
                name: "TeacherHighestDegrees");

            migrationBuilder.DropTable(
                name: "TeacherOtherDegrees");

            migrationBuilder.DropTable(
                name: "TeachersProffesionalInformations");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "aeec0491-041c-4f84-bc97-3b774d6424c3", "ccb5aaa0-0716-4cc6-bd96-23bf2fa1dcaf" });
        }
    }
}
