using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public enum QuestionTwentySevenAnswers
    {
        [DisplayName("Никогда")]
        Never = 0,
        [DisplayName("Раз в месяц или меньше")]
        OnceInMonthOrLess = 1,
        [DisplayName("2-4 раза в месяц")]
        TwoOrFourInMonth = 2,
        [DisplayName("2-3 раза в неделю")]
        TwoOrThreeInWeek = 3,
        [DisplayName(">= 4 раз в неделю")]
        MoreThatFourInWeek = 4
    }
}
