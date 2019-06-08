using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalExaminationWeb.Migrations
{
    public partial class ReturningBackBoolValuesToQuetionarie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTwo",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTwentyTwo",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTwentyThree",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTwentyOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTwentyFour",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTwelve",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionThree",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionThirteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionTen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionSixteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionSix",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionSeventeen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneTwo",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneThree",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneTenOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneTen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneSixOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneSix",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneSeven",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneOneOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneNine",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneFour",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneFive",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionOneEight",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionNineteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionNine",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionFourteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionFour",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionFive",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionFifteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionEleven",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionEighteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "QuestionEight",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuestionTwo",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTwentyTwo",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTwentyThree",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTwentyOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTwentyFour",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTwelve",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionThree",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionThirteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionTen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionSixteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionSix",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionSeventeen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneTwo",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneThree",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneTenOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneTen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneSixOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneSix",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneSeven",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneOneOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneOne",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneNine",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneFour",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneFive",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionOneEight",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionNineteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionNine",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionFourteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionFour",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionFive",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionFifteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionEleven",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionEighteen",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<int>(
                name: "QuestionEight",
                table: "QuestionnaireTill75",
                nullable: false,
                oldClrType: typeof(bool));
        }
    }
}
