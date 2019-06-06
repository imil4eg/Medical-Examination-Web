using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseOutcomeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseOutcomeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExaminationResultTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationResultTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceCompanyTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceCompanyTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PassportIssuePlaceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassportIssuePlaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PositionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Periodicity = table.Column<int>(nullable: false),
                    AgeRange = table.Column<string>(nullable: true),
                    IsIncluded = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    INN = table.Column<string>(nullable: true),
                    SNILS = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    PassportSeries = table.Column<string>(nullable: true),
                    PassportIssueDate = table.Column<DateTime>(nullable: false),
                    PassportIssuePlaceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_PassportIssuePlaceTypes_PassportIssuePlaceId",
                        column: x => x.PassportIssuePlaceId,
                        principalTable: "PassportIssuePlaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProvideServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false),
                    ServiceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvideServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProvideServices_PositionTypes_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PositionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvideServices_ServiceTypes_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    InsuranceNumber = table.Column<string>(nullable: false),
                    InsuranceCompanyId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Patients_InsuranceCompanyTypes_InsuranceCompanyId",
                        column: x => x.InsuranceCompanyId,
                        principalTable: "InsuranceCompanyTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patients_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Workers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    DiseaseOutcomeTypeId = table.Column<Guid>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_DiseaseOutcomeTypes_DiseaseOutcomeTypeId",
                        column: x => x.DiseaseOutcomeTypeId,
                        principalTable: "DiseaseOutcomeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    PositionId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_PositionTypes_PositionId",
                        column: x => x.PositionId,
                        principalTable: "PositionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Positions_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireAfter75",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(nullable: false),
                    QuestionOneOne = table.Column<bool>(nullable: false),
                    QuestionOneOneOne = table.Column<bool>(nullable: false),
                    QuestionOneTwo = table.Column<bool>(nullable: false),
                    QuestionOneTwoOne = table.Column<bool>(nullable: false),
                    QuestionOneThree = table.Column<bool>(nullable: false),
                    QuestionOneThreeOne = table.Column<string>(nullable: true),
                    QuestionOneFour = table.Column<bool>(nullable: false),
                    QuestionOneFourOne = table.Column<bool>(nullable: false),
                    QuestionOneFive = table.Column<bool>(nullable: false),
                    QuestionOneSix = table.Column<bool>(nullable: false),
                    QuestionOneSeven = table.Column<bool>(nullable: false),
                    QuestionTwo = table.Column<bool>(nullable: false),
                    QuestionThree = table.Column<bool>(nullable: false),
                    QuestionFour = table.Column<bool>(nullable: false),
                    QuestionFive = table.Column<bool>(nullable: false),
                    QuestionSix = table.Column<bool>(nullable: false),
                    QuestionSeven = table.Column<bool>(nullable: false),
                    QuestionEight = table.Column<bool>(nullable: false),
                    QuestionNine = table.Column<bool>(nullable: false),
                    QuestionTen = table.Column<bool>(nullable: false),
                    QuestionEleven = table.Column<bool>(nullable: false),
                    QuestionTwelve = table.Column<bool>(nullable: false),
                    QuestionThirteen = table.Column<bool>(nullable: false),
                    QuestionFourteen = table.Column<bool>(nullable: false),
                    QuestionFifteen = table.Column<bool>(nullable: false),
                    QuestionSixteen = table.Column<bool>(nullable: false),
                    QuestionSeventeen = table.Column<bool>(nullable: false),
                    QuestionEighteen = table.Column<bool>(nullable: false),
                    QuestionNineteen = table.Column<bool>(nullable: false),
                    QuestionTwenty = table.Column<bool>(nullable: false),
                    QuestionTwentyOne = table.Column<bool>(nullable: false),
                    QuestionTwentyTwo = table.Column<bool>(nullable: false),
                    QuestionTwentyThree = table.Column<bool>(nullable: false),
                    QuestionTwentyFour = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireAfter75", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_QuestionnaireAfter75_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireTill75",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(nullable: false),
                    QuestionOneOne = table.Column<bool>(nullable: false),
                    QuestionOneOneOne = table.Column<bool>(nullable: false),
                    QuestionOneTwo = table.Column<bool>(nullable: false),
                    QuestionOneThree = table.Column<bool>(nullable: false),
                    QuestionOneFour = table.Column<bool>(nullable: false),
                    QuestionOneFive = table.Column<bool>(nullable: false),
                    QuestionOneSix = table.Column<bool>(nullable: false),
                    QuestionOneSixOne = table.Column<bool>(nullable: false),
                    QuestionOneSeven = table.Column<bool>(nullable: false),
                    QuestionOneEight = table.Column<bool>(nullable: false),
                    QuestionOneNine = table.Column<bool>(nullable: false),
                    QuestionOneNineOne = table.Column<string>(nullable: true),
                    QuestionOneTen = table.Column<bool>(nullable: false),
                    QuestionOneTenOne = table.Column<bool>(nullable: false),
                    QuestionTwo = table.Column<bool>(nullable: false),
                    QuestionThree = table.Column<bool>(nullable: false),
                    QuestionFour = table.Column<bool>(nullable: false),
                    QuestionFive = table.Column<bool>(nullable: false),
                    QuestionSix = table.Column<bool>(nullable: false),
                    QuestionSeven = table.Column<int>(nullable: false),
                    QuestionEight = table.Column<bool>(nullable: false),
                    QuestionNine = table.Column<bool>(nullable: false),
                    QuestionTen = table.Column<bool>(nullable: false),
                    QuestionEleven = table.Column<bool>(nullable: false),
                    QuestionTwelve = table.Column<bool>(nullable: false),
                    QuestionThirteen = table.Column<bool>(nullable: false),
                    QuestionFourteen = table.Column<bool>(nullable: false),
                    QuestionFifteen = table.Column<bool>(nullable: false),
                    QuestionSixteen = table.Column<bool>(nullable: false),
                    QuestionSeventeen = table.Column<bool>(nullable: false),
                    QuestionEighteen = table.Column<bool>(nullable: false),
                    QuestionNineteen = table.Column<bool>(nullable: false),
                    QuestionTwenty = table.Column<int>(nullable: false),
                    QuestionTwentyOne = table.Column<bool>(nullable: false),
                    QuestionTwentyTwo = table.Column<bool>(nullable: false),
                    QuestionTwentyThree = table.Column<bool>(nullable: false),
                    QuestionTwentyFour = table.Column<bool>(nullable: false),
                    QuestionTwentyFive = table.Column<int>(nullable: false),
                    QuestionTwentySix = table.Column<int>(nullable: false),
                    QuestionTwentySeven = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionnaireTill75", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_QuestionnaireTill75_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: false),
                    ServiceTypeId = table.Column<Guid>(nullable: false),
                    WorkerId = table.Column<int>(nullable: false),
                    Result = table.Column<string>(nullable: true),
                    TubeNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceResult_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceResult_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceResult_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DiseaseOutcomeTypeId",
                table: "Appointments",
                column: "DiseaseOutcomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkerId",
                table: "Appointments",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkerId",
                table: "AspNetUsers",
                column: "WorkerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_InsuranceCompanyId",
                table: "Patients",
                column: "InsuranceCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PassportIssuePlaceId",
                table: "Persons",
                column: "PassportIssuePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_PositionId",
                table: "Positions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_WorkerId",
                table: "Positions",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideServices_PositionId",
                table: "ProvideServices",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideServices_ServiceId",
                table: "ProvideServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceResult_AppointmentId",
                table: "ServiceResult",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceResult_ServiceTypeId",
                table: "ServiceResult",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceResult_WorkerId",
                table: "ServiceResult",
                column: "WorkerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ExaminationResultTypes");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "ProvideServices");

            migrationBuilder.DropTable(
                name: "QuestionnaireAfter75");

            migrationBuilder.DropTable(
                name: "QuestionnaireTill75");

            migrationBuilder.DropTable(
                name: "ServiceResult");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PositionTypes");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "DiseaseOutcomeTypes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "InsuranceCompanyTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "PassportIssuePlaceTypes");
        }
    }
}
