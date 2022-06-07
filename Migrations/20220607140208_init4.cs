using Microsoft.EntityFrameworkCore.Migrations;

namespace Careerio.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_RemoteRecruitmentId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_TypeOfContractId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_WorkingHoursID",
                table: "JobOffers");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_RemoteRecruitmentId",
                table: "JobOffers",
                column: "RemoteRecruitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_TypeOfContractId",
                table: "JobOffers",
                column: "TypeOfContractId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_WorkingHoursID",
                table: "JobOffers",
                column: "WorkingHoursID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_RemoteRecruitmentId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_TypeOfContractId",
                table: "JobOffers");

            migrationBuilder.DropIndex(
                name: "IX_JobOffers_WorkingHoursID",
                table: "JobOffers");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_RemoteRecruitmentId",
                table: "JobOffers",
                column: "RemoteRecruitmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_TypeOfContractId",
                table: "JobOffers",
                column: "TypeOfContractId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_WorkingHoursID",
                table: "JobOffers",
                column: "WorkingHoursID",
                unique: true);
        }
    }
}
