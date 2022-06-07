using Microsoft.EntityFrameworkCore.Migrations;

namespace Careerio.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Companies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_CreatedById",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CreatedById",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Companies");
        }
    }
}
