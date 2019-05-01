using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class AddCodesForServiceTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DiseaseOutcomeTypes_DiseaseOutcomeId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "DiseaseOutcomeId",
                table: "Appointments",
                newName: "DiseaseOutcomeTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DiseaseOutcomeId",
                table: "Appointments",
                newName: "IX_Appointments_DiseaseOutcomeTypeId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ServiceTypes",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DiseaseOutcomeTypes_DiseaseOutcomeTypeId",
                table: "Appointments",
                column: "DiseaseOutcomeTypeId",
                principalTable: "DiseaseOutcomeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DiseaseOutcomeTypes_DiseaseOutcomeTypeId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ServiceTypes");

            migrationBuilder.RenameColumn(
                name: "DiseaseOutcomeTypeId",
                table: "Appointments",
                newName: "DiseaseOutcomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DiseaseOutcomeTypeId",
                table: "Appointments",
                newName: "IX_Appointments_DiseaseOutcomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DiseaseOutcomeTypes_DiseaseOutcomeId",
                table: "Appointments",
                column: "DiseaseOutcomeId",
                principalTable: "DiseaseOutcomeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
