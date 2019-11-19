using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class UpdateLocationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationCategories_LocationCategoryId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Locations");

            migrationBuilder.AlterColumn<long>(
                name: "LocationCategoryId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationCategories_LocationCategoryId",
                table: "Locations",
                column: "LocationCategoryId",
                principalTable: "LocationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_LocationCategories_LocationCategoryId",
                table: "Locations");

            migrationBuilder.AlterColumn<long>(
                name: "LocationCategoryId",
                table: "Locations",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Locations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_LocationCategories_LocationCategoryId",
                table: "Locations",
                column: "LocationCategoryId",
                principalTable: "LocationCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
