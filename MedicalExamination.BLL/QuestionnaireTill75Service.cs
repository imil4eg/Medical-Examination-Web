using System;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public class QuestionnaireTill75Service : IQuestionnaireTill75Service
    {
        private readonly IGenericRepository<QuestionnaireTill75> _questionnaireRepository;

        public QuestionnaireTill75Service(IGenericRepository<QuestionnaireTill75> questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public QuestionnaireTill75 GetQuestionnaireByAppointmentId(Guid appointmentId)
        {
            return _questionnaireRepository.GetById(appointmentId);
        }

        public void UpdateQuestionnaire(QuestionnaireTill75 questionnaire)
        {
            var updateQuestionnaire = _questionnaireRepository.GetById(questionnaire.AppointmentId);

            updateQuestionnaire = SimpleMapper.Mapper.Map(questionnaire, updateQuestionnaire);

            _questionnaireRepository.Update(updateQuestionnaire);
        }

        public void DeleteQuestionnaire(QuestionnaireTill75 questionnaire)
        {
            throw new NotImplementedException();
        }

        public void CreateQuestionnaire(QuestionnaireTill75 questionnaire)
        {
            throw new NotImplementedException();
        }
    }
}
