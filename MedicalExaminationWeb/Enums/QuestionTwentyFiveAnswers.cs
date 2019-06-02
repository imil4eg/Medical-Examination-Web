using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public enum QuestionTwentyFiveAnswers
    {
        [DisplayName("Никогда")]
        Never = 0,
        [DisplayName("Раз в месяц")]
        OnceInMonth = 1,
        [DisplayName("2-4 раза в месяц")]
        PareInMonth = 2,
        [DisplayName("2-3 раза в неделею")]
        PareInWeek = 3,
        [DisplayName(">=4 раз в неделю")]
        MoreThanFourInWeek = 4
    }
}
