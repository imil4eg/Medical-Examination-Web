using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public enum QuestionSevenAnswers
    {
        [DisplayName("Нет")]
        No = 0,
        [DisplayName("Да, исчезает после приема нитроглецерина")]
        YesWithNitroglycerin = 1,
        [DisplayName("Да, исчезает самостоятельно")]
        YesByItSelf = 2
    }
}
