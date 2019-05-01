using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalExamination.Entities
{
    [Flags]
    public enum QuestionTwentyFiveAnswers
    {
        [Display(Name = "Никогда")]
        Never = 0,
        [Display(Name = "Раз в месяц")]
        OnceInMonth = 1,
        [Display(Name = "2-4 раза в месяц")]
        PareInMonth = 2,
        [Display(Name = "2-3 раза в неделею")]
        PareInWeek = 3,
        [Display(Name = ">=4 раз в неделю")]
        MoreThanFourInWeek = 4
    }
}
