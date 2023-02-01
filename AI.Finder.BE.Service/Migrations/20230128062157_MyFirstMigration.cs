using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AI.Finder.BE.Service.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sample",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<long>(type: "bigint", nullable: false),
                    AuditProp = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sample", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    EmailId = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    PassowrdSalt = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmationToken = table.Column<string>(type: "text", nullable: true),
                    EmailTokenGeneratedTimestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhoneConfirmationToken = table.Column<string>(type: "text", nullable: true),
                    PhoneTokenGeneratedTimestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoleCode = table.Column<string>(type: "text", nullable: true),
                    RoleName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sample_Code",
                table: "sample",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_EmailId",
                table: "user",
                column: "EmailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_PhoneNumber",
                table: "user",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_UserId",
                table: "user",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sample");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
