using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class AddedServiceResultEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceResults_Appointments_AppointmentId",
                table: "ServiceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceResults_ServiceTypes_ServiceTypeId",
                table: "ServiceResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceResults",
                table: "ServiceResults");

            migrationBuilder.RenameTable(
                name: "ServiceResults",
                newName: "ServiceResult");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceResults_ServiceTypeId",
                table: "ServiceResult",
                newName: "IX_ServiceResult_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceResults_AppointmentId",
                table: "ServiceResult",
                newName: "IX_ServiceResult_AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceResult",
                table: "ServiceResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceResult_Appointments_AppointmentId",
                table: "ServiceResult",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceResult_ServiceTypes_ServiceTypeId",
                table: "ServiceResult",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceResult_Appointments_AppointmentId",
                table: "ServiceResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceResult_ServiceTypes_ServiceTypeId",
                table: "ServiceResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceResult",
                table: "ServiceResult");

            migrationBuilder.RenameTable(
                name: "ServiceResult",
                newName: "ServiceResults");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceResult_ServiceTypeId",
                table: "ServiceResults",
                newName: "IX_ServiceResults_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceResult_AppointmentId",
                table: "ServiceResults",
                newName: "IX_ServiceResults_AppointmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceResults",
                table: "ServiceResults",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceResults_Appointments_AppointmentId",
                table: "ServiceResults",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceResults_ServiceTypes_ServiceTypeId",
                table: "ServiceResults",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
