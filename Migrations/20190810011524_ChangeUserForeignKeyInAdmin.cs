using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolManagementSystem.Migrations
{
    public partial class ChangeUserForeignKeyInAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_IdentityUserId1",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_IdentityUserId1",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "IdentityUserId1",
                table: "Admins");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "Admins",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdentityUserId",
                table: "Admins",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_IdentityUserId",
                table: "Admins",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_IdentityUserId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_IdentityUserId",
                table: "Admins");

            migrationBuilder.AlterColumn<int>(
                name: "IdentityUserId",
                table: "Admins",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId1",
                table: "Admins",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_IdentityUserId1",
                table: "Admins",
                column: "IdentityUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_IdentityUserId1",
                table: "Admins",
                column: "IdentityUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
