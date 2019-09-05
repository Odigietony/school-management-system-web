using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class AddCascadingTeacherTables : Migration
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
                    ZipCode = table.Column<int>(nullable: false),
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
                    TeacherContactInfoId = table.Column<long>(nullable: false),
                    TeacherContactInformationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherHighestDegrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherHighestDegrees_TeacherContactInformations_TeacherContactInformationId",
                        column: x => x.TeacherContactInformationId,
                        principalTable: "TeacherContactInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TeacherHighestDegreeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOtherDegrees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherOtherDegrees_TeacherHighestDegrees_TeacherHighestDegreeId",
                        column: x => x.TeacherHighestDegreeId,
                        principalTable: "TeacherHighestDegrees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4475e8be-7a6a-4d70-ade3-d3afc69c5faf", "2f261e83-79e4-4d2f-be75-0175a1d8919b" });

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

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CountryId", "StateName" },
                values: new object[,]
                {
                    { 1L, 1L, "Kabul" },
                    { 88L, 9L, "Canberra–Queanbeyan" },
                    { 87L, 9L, "Newcastle–Maitland" },
                    { 86L, 9L, "Gold Coast–Tweed Heads" },
                    { 85L, 9L, "Adelaide" },
                    { 84L, 9L, "Perth" },
                    { 83L, 9L, "Brisbane" },
                    { 82L, 9L, "Melbourne" },
                    { 81L, 9L, "Sydney" },
                    { 80L, 8L, "Vayots Dzor" },
                    { 79L, 8L, "Tavush" },
                    { 78L, 8L, "Syunik" },
                    { 77L, 8L, "Shirak" },
                    { 89L, 9L, "Sunshine Coast" },
                    { 76L, 8L, "Lori" },
                    { 74L, 8L, "Gegharkunik" },
                    { 73L, 8L, "Armavir" },
                    { 72L, 8L, "Ararat" },
                    { 71L, 8L, "Aragatsotn" },
                    { 70L, 7L, "La Pampa" },
                    { 69L, 7L, "Jujuy" },
                    { 68L, 7L, "Formosa" },
                    { 67L, 7L, "Between Rivers" },
                    { 66L, 7L, "Currents" },
                    { 65L, 7L, "Cordoba" },
                    { 64L, 7L, "Chubut" },
                    { 63L, 7L, "Chaco" },
                    { 75L, 8L, "Kotayk" },
                    { 62L, 7L, "Catamarca" },
                    { 90L, 9L, "Wollongong" },
                    { 92L, 10L, "Graz" },
                    { 118L, 12L, "Andros Town" },
                    { 117L, 12L, "Bahamas City" },
                    { 116L, 12L, "Freetown" },
                    { 115L, 12L, "Marsh Harbour" },
                    { 114L, 12L, "Coopers Town" },
                    { 113L, 12L, "West End" },
                    { 112L, 12L, "Freeport" },
                    { 111L, 12L, "Nassau" },
                    { 110L, 11L, "Beylagan" },
                    { 109L, 11L, "Barda" },
                    { 108L, 11L, "Balakən" },
                    { 107L, 11L, "Baku" },
                    { 91L, 10L, "Vienna" },
                    { 106L, 11L, "Babek" },
                    { 104L, 11L, "Agsu" },
                    { 103L, 11L, "Agstafa" },
                    { 102L, 11L, "Agjabadi" },
                    { 101L, 11L, "Agdash" },
                    { 100L, 10L, "Dornbirn" },
                    { 99L, 10L, "Sankt Pölten" },
                    { 98L, 10L, "Wels" },
                    { 97L, 10L, "Villach" },
                    { 96L, 10L, "Klagenfurt" },
                    { 95L, 10L, "Innsbruck" },
                    { 94L, 10L, "Salzburg" },
                    { 93L, 10L, "Linz" },
                    { 105L, 11L, "Astara" },
                    { 61L, 7L, "Buenos Aires" },
                    { 60L, 6L, "Falmouth" },
                    { 59L, 6L, "English Harbour" },
                    { 27L, 3L, "Djelfa" },
                    { 26L, 3L, "Batna" },
                    { 25L, 3L, "Blida" },
                    { 24L, 3L, "Annaba" },
                    { 23L, 3L, "Constantine" },
                    { 22L, 3L, "Oran" },
                    { 21L, 3L, "Algiers" },
                    { 20L, 2L, "Lushnjë" },
                    { 19L, 2L, "Berat" },
                    { 18L, 2L, "Korçë" },
                    { 17L, 2L, "Kamëz" },
                    { 16L, 2L, "Fier" },
                    { 28L, 3L, "Sétif" },
                    { 15L, 2L, "Shkodër" },
                    { 13L, 2L, "Vlorë" },
                    { 12L, 2L, "Durrës" },
                    { 11L, 2L, "Tirana" },
                    { 10L, 1L, "Taloqan" },
                    { 9L, 1L, "Lashkargah" },
                    { 8L, 1L, "Ghazni" },
                    { 7L, 1L, "Kunduz" },
                    { 6L, 1L, "Jalalabad" },
                    { 5L, 1L, "Kabul" },
                    { 4L, 1L, "Mazar-i-Sharif" },
                    { 3L, 1L, "Herat" },
                    { 2L, 1L, "Kandahar" },
                    { 14L, 2L, "Elbasan" },
                    { 29L, 3L, "Sidi Bel Abbès" },
                    { 30L, 3L, "Biskra" },
                    { 31L, 4L, "Canillo" },
                    { 58L, 6L, "Dickenson Bay" },
                    { 57L, 6L, "Codrington" },
                    { 56L, 6L, "Cedar Grove" },
                    { 55L, 6L, "Clare Hall" },
                    { 54L, 6L, "Carlisle, Saint Philip" },
                    { 53L, 6L, "Carlisle, Saint George" },
                    { 52L, 6L, "Bolans" },
                    { 51L, 6L, "All Saints" },
                    { 50L, 5L, "Bungo" },
                    { 49L, 5L, "Biula" },
                    { 48L, 5L, "Bimbe" },
                    { 47L, 5L, "Bibala (Vila Arriaga)" },
                    { 46L, 5L, "Benguela" },
                    { 45L, 5L, "Baía Farta" },
                    { 44L, 5L, "Balombo" },
                    { 43L, 5L, "Bailundo" },
                    { 42L, 5L, "Andulo" },
                    { 41L, 5L, "Ambriz" },
                    { 40L, 4L, "Prats" },
                    { 39L, 4L, "Els Plans" },
                    { 38L, 4L, "Molleres" },
                    { 37L, 4L, "Meritxell" },
                    { 36L, 4L, "Incles" },
                    { 35L, 4L, "El Forn" },
                    { 34L, 4L, "Bordes d'Envalira" },
                    { 33L, 4L, "L'Armiana" },
                    { 32L, 4L, "L'Aldosa" },
                    { 119L, 12L, "Clarence Town" },
                    { 120L, 12L, "Dunmore Town" }
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
                name: "IX_TeacherHighestDegrees_TeacherContactInformationId",
                table: "TeacherHighestDegrees",
                column: "TeacherContactInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherOtherDegrees_TeacherHighestDegreeId",
                table: "TeacherOtherDegrees",
                column: "TeacherHighestDegreeId");

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
                name: "TeacherOtherDegrees");

            migrationBuilder.DropTable(
                name: "TeachersProffesionalInformations");

            migrationBuilder.DropTable(
                name: "TeacherHighestDegrees");

            migrationBuilder.DropTable(
                name: "Referees");

            migrationBuilder.DropTable(
                name: "TeacherContactInformations");

            migrationBuilder.DropTable(
                name: "Countries");

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
