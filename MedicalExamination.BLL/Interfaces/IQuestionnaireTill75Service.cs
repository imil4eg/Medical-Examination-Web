using System;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public interface IQuestionnaireTill75Service
    {
        QuestionnaireTill75 GetQuestionnaireByAppointmentId(Guid appointmentId);
        void UpdateQuestionnaire(QuestionnaireTill75 questionnaire);
        void DeleteQuestionnaire(QuestionnaireTill75 questionnaire);
        void CreateQuestionnaire(QuestionnaireTill75 questionnaire);
    }
}
