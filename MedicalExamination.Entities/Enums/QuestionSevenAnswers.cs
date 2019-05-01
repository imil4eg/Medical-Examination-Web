using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalExamination.Entities
{
    [Flags]
    public enum QuestionSevenAnswers
    {
        [Display(Name = "Нет")]
        No = 0,
        [Display(Name = "Да, исчезает после приема нитроглецерина")]
        YesWithNitroglycerin = 1,
        [Display(Name = "Да, исчезает самостоятельно")]
        YesByItSelf = 2
    }
}
