using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class ServiceTypeUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeForService",
                table: "ServiceTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "ServiceTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeForService",
                table: "ServiceTypes");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "ServiceTypes");
        }
    }
}
