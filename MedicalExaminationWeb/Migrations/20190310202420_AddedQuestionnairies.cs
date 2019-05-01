using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class AddedQuestionnairies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuestionnaireAfter75s",
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
                    table.PrimaryKey("PK_QuestionnaireAfter75s", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_QuestionnaireAfter75s_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionnaireTill75s",
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
                    table.PrimaryKey("PK_QuestionnaireTill75s", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_QuestionnaireTill75s_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionnaireAfter75s");

            migrationBuilder.DropTable(
                name: "QuestionnaireTill75s");
        }
    }
}
