using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class ColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeForService",
                table: "ServiceTypes",
                newName: "AgeRange");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AgeRange",
                table: "ServiceTypes",
                newName: "AgeForService");
        }
    }
}
