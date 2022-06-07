using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Careerio.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExperienceLevels",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    ExperienceLevelDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemoteRecruitments",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    IsRemoteRecruitment = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemoteRecruitments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Requirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsibilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Responsibilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfContracts",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    TypeOfContractDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shortcut = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfContracts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingHours",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    WorkingHoursDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    TypeOfContractId = table.Column<byte>(type: "tinyint", nullable: false),
                    ExperienceLevelId = table.Column<byte>(type: "tinyint", nullable: false),
                    RemoteRecruitmentId = table.Column<byte>(type: "tinyint", nullable: false),
                    WorkingHoursID = table.Column<byte>(type: "tinyint", nullable: false),
                    ResponsibilityId = table.Column<int>(type: "int", nullable: false),
                    RequirementId = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SalaryFrom = table.Column<int>(type: "int", nullable: false),
                    SalaryTo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_ExperienceLevels_ExperienceLevelId",
                        column: x => x.ExperienceLevelId,
                        principalTable: "ExperienceLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_RemoteRecruitments_RemoteRecruitmentId",
                        column: x => x.RemoteRecruitmentId,
                        principalTable: "RemoteRecruitments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_Requirements_RequirementId",
                        column: x => x.RequirementId,
                        principalTable: "Requirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_Responsibilities_ResponsibilityId",
                        column: x => x.ResponsibilityId,
                        principalTable: "Responsibilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_TypeOfContracts_TypeOfContractId",
                        column: x => x.TypeOfContractId,
                        principalTable: "TypeOfContracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobOffers_WorkingHours_WorkingHoursID",
                        column: x => x.WorkingHoursID,
                        principalTable: "WorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_CompanyId",
                table: "JobOffers",
                column: "CompanyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ExperienceLevelId",
                table: "JobOffers",
                column: "ExperienceLevelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_RemoteRecruitmentId",
                table: "JobOffers",
                column: "RemoteRecruitmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_RequirementId",
                table: "JobOffers",
                column: "RequirementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobOffers_ResponsibilityId",
                table: "JobOffers",
                column: "ResponsibilityId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobOffers");

            migrationBuilder.DropTable(
                name: "ExperienceLevels");

            migrationBuilder.DropTable(
                name: "RemoteRecruitments");

            migrationBuilder.DropTable(
                name: "Requirements");

            migrationBuilder.DropTable(
                name: "Responsibilities");

            migrationBuilder.DropTable(
                name: "TypeOfContracts");

            migrationBuilder.DropTable(
                name: "WorkingHours");
        }
    }
}
