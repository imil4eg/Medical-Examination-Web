using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class RemovedDiagnosisType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireAfter75s_Appointments_AppointmentId",
                table: "QuestionnaireAfter75s");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireTill75s_Appointments_AppointmentId",
                table: "QuestionnaireTill75s");

            migrationBuilder.DropTable(
                name: "PatientDiagnoses");

            migrationBuilder.DropTable(
                name: "DiagnosesTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionnaireTill75s",
                table: "QuestionnaireTill75s");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionnaireAfter75s",
                table: "QuestionnaireAfter75s");

            migrationBuilder.RenameTable(
                name: "QuestionnaireTill75s",
                newName: "QuestionnaireTill75");

            migrationBuilder.RenameTable(
                name: "QuestionnaireAfter75s",
                newName: "QuestionnaireAfter75");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionnaireTill75",
                table: "QuestionnaireTill75",
                column: "AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionnaireAfter75",
                table: "QuestionnaireAfter75",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireAfter75_Appointments_AppointmentId",
                table: "QuestionnaireAfter75",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireTill75_Appointments_AppointmentId",
                table: "QuestionnaireTill75",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireAfter75_Appointments_AppointmentId",
                table: "QuestionnaireAfter75");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionnaireTill75_Appointments_AppointmentId",
                table: "QuestionnaireTill75");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionnaireTill75",
                table: "QuestionnaireTill75");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QuestionnaireAfter75",
                table: "QuestionnaireAfter75");

            migrationBuilder.RenameTable(
                name: "QuestionnaireTill75",
                newName: "QuestionnaireTill75s");

            migrationBuilder.RenameTable(
                name: "QuestionnaireAfter75",
                newName: "QuestionnaireAfter75s");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionnaireTill75s",
                table: "QuestionnaireTill75s",
                column: "AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QuestionnaireAfter75s",
                table: "QuestionnaireAfter75s",
                column: "AppointmentId");

            migrationBuilder.CreateTable(
                name: "DiagnosesTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosesTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiagnoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppointmentId = table.Column<Guid>(nullable: false),
                    DiagnosisId = table.Column<Guid>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiagnoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDiagnoses_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDiagnoses_DiagnosesTypes_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "DiagnosesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnoses_AppointmentId",
                table: "PatientDiagnoses",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnoses_DiagnosisId",
                table: "PatientDiagnoses",
                column: "DiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireAfter75s_Appointments_AppointmentId",
                table: "QuestionnaireAfter75s",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionnaireTill75s_Appointments_AppointmentId",
                table: "QuestionnaireTill75s",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
