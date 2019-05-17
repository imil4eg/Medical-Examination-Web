using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class AddedServiceTypeBoolAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsIncluded",
                table: "ServiceTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIncluded",
                table: "ServiceTypes");
        }
    }
}
