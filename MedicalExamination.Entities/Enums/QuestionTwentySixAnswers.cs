using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalExamination.Entities
{
    [Flags]
    public enum QuestionTwentySixAnswers
    {
        [Display(Name = "1-2 порции")]
        TwoOrOne = 0,
        [Display(Name = "3-4 порции")]
        ThreeOrFour = 1,
        [Display(Name = "5-6 порций")]
        FiveOrSix = 2,
        [Display(Name = "7-9 порций")]
        SevenOrNine = 3,
        [Display(Name = ">= 10 порций")]
        MoreThanTen = 4
    }
}
