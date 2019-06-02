using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public enum QuestionTwentyOneAnswers
    {
        [DisplayName("До 30 минут")]
        TillThirtyMinutes = 0,
        [DisplayName("30 минут и более")]
        ThirtyOrMoreMinutes = 1
    }
}
