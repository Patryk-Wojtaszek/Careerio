using Microsoft.EntityFrameworkCore.Migrations;

namespace Careerio.Migrations
{
    public partial class deleteindustry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_RelatedIndustries_RelatedIndustryId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RelatedIndustryId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "RelatedIndustryId",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "RelatedIndustries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RelatedIndustries_CompanyId",
                table: "RelatedIndustries",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatedIndustries_Companies_CompanyId",
                table: "RelatedIndustries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatedIndustries_Companies_CompanyId",
                table: "RelatedIndustries");

            migrationBuilder.DropIndex(
                name: "IX_RelatedIndustries_CompanyId",
                table: "RelatedIndustries");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "RelatedIndustries");

            migrationBuilder.AddColumn<int>(
                name: "RelatedIndustryId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RelatedIndustryId",
                table: "Companies",
                column: "RelatedIndustryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_RelatedIndustries_RelatedIndustryId",
                table: "Companies",
                column: "RelatedIndustryId",
                principalTable: "RelatedIndustries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
