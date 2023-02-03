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
                name: "activity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "address_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsRelationalData = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blood_group",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blood_group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "body_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_body_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "complexion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complexion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "language",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "marital_status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marital_status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "religion",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parentid = table.Column<long>(type: "bigint", nullable: true),
                    treepath = table.Column<string>(type: "ltree", nullable: true),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_religion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "resident_type",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resident_type", x => x.Id);
                });

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
                name: "SampleAutherization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleAutherization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    BaseValue = table.Column<float>(type: "real", nullable: false),
                    ConversionUnit = table.Column<short>(type: "smallint", nullable: false),
                    IsVisible = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit", x => x.Id);
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
                    PhoneTokenGeneratedTimestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.Id);
                    table.ForeignKey(
                        name: "FK_state_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "district",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_district", x => x.Id);
                    table.ForeignKey(
                        name: "FK_district_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "town",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_town", x => x.Id);
                    table.ForeignKey(
                        name: "FK_town_district_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "district",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "candidate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenderId = table.Column<long>(type: "bigint", nullable: true),
                    UnitsId = table.Column<long>(type: "bigint", nullable: true),
                    ComplexionId = table.Column<long>(type: "bigint", nullable: true),
                    BodyTypeId = table.Column<long>(type: "bigint", nullable: true),
                    MaritalStatusId = table.Column<long>(type: "bigint", nullable: true),
                    ChildrenWithMe = table.Column<int>(type: "integer", nullable: false),
                    ChildrenNotWithMe = table.Column<int>(type: "integer", nullable: false),
                    BloodGroupId = table.Column<long>(type: "bigint", nullable: true),
                    ResidentCountryId = table.Column<long>(type: "bigint", nullable: true),
                    ResidentStateId = table.Column<long>(type: "bigint", nullable: true),
                    ResidentDistrctId = table.Column<long>(type: "bigint", nullable: true),
                    ResidentsTownId = table.Column<long>(type: "bigint", nullable: true),
                    ResidentTown = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    ResidentTypeId = table.Column<long>(type: "bigint", nullable: true),
                    NativeDistrictId = table.Column<long>(type: "bigint", nullable: true),
                    NativesTownId = table.Column<long>(type: "bigint", nullable: true),
                    NativeTown = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    MotherTongueId = table.Column<long>(type: "bigint", nullable: true),
                    ReligionTreePath = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsSpecialNeed = table.Column<bool>(type: "boolean", nullable: false),
                    IsResident = table.Column<bool>(type: "boolean", nullable: false),
                    HeightInCentimeter = table.Column<long>(type: "bigint", nullable: false),
                    WeightInKilogram = table.Column<short>(type: "smallint", nullable: false),
                    OtherReligion = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    OtherReligiousInformation = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    AboutMe = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CandidateAssetDetails = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    TwinsCandidateId = table.Column<long>(type: "bigint", nullable: true),
                    RegistrationId = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    CreatedContactId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_candidate_address_type_CreatedContactId",
                        column: x => x.CreatedContactId,
                        principalTable: "address_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_blood_group_BloodGroupId",
                        column: x => x.BloodGroupId,
                        principalTable: "blood_group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_body_type_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "body_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_candidate_TwinsCandidateId",
                        column: x => x.TwinsCandidateId,
                        principalTable: "candidate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_complexion_ComplexionId",
                        column: x => x.ComplexionId,
                        principalTable: "complexion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_country_ResidentCountryId",
                        column: x => x.ResidentCountryId,
                        principalTable: "country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_district_NativeDistrictId",
                        column: x => x.NativeDistrictId,
                        principalTable: "district",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_district_ResidentDistrctId",
                        column: x => x.ResidentDistrctId,
                        principalTable: "district",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "gender",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_language_MotherTongueId",
                        column: x => x.MotherTongueId,
                        principalTable: "language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_marital_status_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "marital_status",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_resident_type_ResidentTypeId",
                        column: x => x.ResidentTypeId,
                        principalTable: "resident_type",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_state_ResidentStateId",
                        column: x => x.ResidentStateId,
                        principalTable: "state",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_town_NativesTownId",
                        column: x => x.NativesTownId,
                        principalTable: "town",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_town_ResidentsTownId",
                        column: x => x.ResidentsTownId,
                        principalTable: "town",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_candidate_unit_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_blood_group_Name",
                table: "blood_group",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_body_type_Name",
                table: "body_type",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_candidate_BloodGroupId",
                table: "candidate",
                column: "BloodGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_BodyTypeId",
                table: "candidate",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_ComplexionId",
                table: "candidate",
                column: "ComplexionId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_CreatedContactId",
                table: "candidate",
                column: "CreatedContactId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_GenderId",
                table: "candidate",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_MaritalStatusId",
                table: "candidate",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_MotherTongueId",
                table: "candidate",
                column: "MotherTongueId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_NativeDistrictId",
                table: "candidate",
                column: "NativeDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_NativesTownId",
                table: "candidate",
                column: "NativesTownId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_ResidentCountryId",
                table: "candidate",
                column: "ResidentCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_ResidentDistrctId",
                table: "candidate",
                column: "ResidentDistrctId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_ResidentStateId",
                table: "candidate",
                column: "ResidentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_ResidentsTownId",
                table: "candidate",
                column: "ResidentsTownId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_ResidentTypeId",
                table: "candidate",
                column: "ResidentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_TwinsCandidateId",
                table: "candidate",
                column: "TwinsCandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_UnitsId",
                table: "candidate",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_complexion_Name",
                table: "complexion",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_country_Name",
                table: "country",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_district_StateId",
                table: "district",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_gender_Name",
                table: "gender",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_language_Name",
                table: "language",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_marital_status_Name",
                table: "marital_status",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_religion_name",
                table: "religion",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_resident_type_Name",
                table: "resident_type",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sample_Code",
                table: "sample",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_state_CountryId",
                table: "state",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_state_Name",
                table: "state",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_town_DistrictId",
                table: "town",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_town_Name",
                table: "town",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unit_Code",
                table: "unit",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_unit_Name",
                table: "unit",
                column: "Name",
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
                name: "activity");

            migrationBuilder.DropTable(
                name: "candidate");

            migrationBuilder.DropTable(
                name: "religion");

            migrationBuilder.DropTable(
                name: "sample");

            migrationBuilder.DropTable(
                name: "SampleAutherization");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "address_type");

            migrationBuilder.DropTable(
                name: "blood_group");

            migrationBuilder.DropTable(
                name: "body_type");

            migrationBuilder.DropTable(
                name: "complexion");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "language");

            migrationBuilder.DropTable(
                name: "marital_status");

            migrationBuilder.DropTable(
                name: "resident_type");

            migrationBuilder.DropTable(
                name: "town");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "district");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
