using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalExamination.Entities
{
    [Flags]
    public enum QuestionTwentySevenAnswers
    {
        [Display(Name = "Никогда")]
        Never = 0,
        [Display(Name = "Раз в месяц или меньше")]
        OnceInMonthOrLess = 1,
        [Display(Name = "2-4 раза в месяц")]
        TwoOrFourInMonth = 2,
        [Display(Name = "2-3 раза в неделю")]
        TwoOrThreeInWeek = 3,
        [Display(Name = ">= 4 раз в неделю")]
        MoreThatFourInWeek = 4
    }
}
