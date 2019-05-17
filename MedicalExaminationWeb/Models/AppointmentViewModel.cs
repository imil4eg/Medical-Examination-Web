using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExaminationWeb
{
    public sealed class AppointmentViewModel
    {
        public AppointmentViewModel()
        {
            this.EndDate = DateTime.Today;
        }

        public WorkerViewModel Worker { get; set; }

        public PatientViewModel Patient { get; set; }

        public DiseaseOutcomeModel Outcome { get; set; }

        public ExaminationResultModel ExaminationResult { get; set; }

        public DateTime EndDate { get; set; }

        public IEnumerable<ServiceResultModel> ServicesResults { get; set; }

        public QuestionnaireAfter75 QuestionnaireAfter75 { get; set; }

        public QuestionnaireTill75 QuestionnaireTill75 { get; set; }
    }
}
