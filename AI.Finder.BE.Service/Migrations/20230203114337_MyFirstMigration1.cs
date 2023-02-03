using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AI.Finder.BE.Service.Migrations
{
    public partial class MyFirstMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "activity_log",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    CandidateId = table.Column<long>(type: "bigint", nullable: true),
                    ActivityTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_log", x => x.Id);
                    table.ForeignKey(
                        name: "FK_activity_log_activity_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "activity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_activity_log_candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "candidate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_activity_log_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_activity_Code",
                table: "activity",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_activity_log_ActivityTypeId",
                table: "activity_log",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_activity_log_CandidateId",
                table: "activity_log",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_activity_log_UserId",
                table: "activity_log",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_log");

            migrationBuilder.DropIndex(
                name: "IX_activity_Code",
                table: "activity");
        }
    }
}
