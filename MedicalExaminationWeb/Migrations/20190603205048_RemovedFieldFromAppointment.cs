using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class RemovedFieldFromAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ExaminationResultTypes_ExaminationResultId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ExaminationResultId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ExaminationResultId",
                table: "Appointments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExaminationResultId",
                table: "Appointments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ExaminationResultId",
                table: "Appointments",
                column: "ExaminationResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ExaminationResultTypes_ExaminationResultId",
                table: "Appointments",
                column: "ExaminationResultId",
                principalTable: "ExaminationResultTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
