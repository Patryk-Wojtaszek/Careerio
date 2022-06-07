using Microsoft.EntityFrameworkCore.Migrations;

namespace Careerio.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobOffers_ExperienceLevelId",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "dateTime",
                table: "JobOffers",
                newName: "DateTime");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ExperienceLevelId",
                table: "JobOffers",
                column: "ExperienceLevelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobOffers_ExperienceLevelId",
                table: "JobOffers");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "JobOffers",
                newName: "dateTime");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ExperienceLevelId",
                table: "JobOffers",
                column: "ExperienceLevelId",
                unique: true);
        }
    }
}
