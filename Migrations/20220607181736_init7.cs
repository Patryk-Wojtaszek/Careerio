using Microsoft.EntityFrameworkCore.Migrations;

namespace Careerio.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "JobOffers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CreatedById",
                table: "JobOffers",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOffers_Users_CreatedById",
                table: "JobOffers",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOffers_Users_CreatedById",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CreatedById",
                table: "JobOffers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "JobOffers");
        }
    }
}
