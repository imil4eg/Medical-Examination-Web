using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class AddedPeriodicityForServiceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Periodicity",
                table: "ServiceTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Periodicity",
                table: "ServiceTypes");
        }
    }
}
