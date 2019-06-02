using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationWeb
{
    public enum QuestionTwentySixAnswers
    {
        [DisplayName("1-2 порции")]
        TwoOrOne = 0,
        [DisplayName("3-4 порции")]
        ThreeOrFour = 1,
        [DisplayName("5-6 порций")]
        FiveOrSix = 2,
        [DisplayName("7-9 порций")]
        SevenOrNine = 3,
        [DisplayName(">= 10 порций")]
        MoreThanTen = 4
    }
}
