using System;
using System.Collections.Generic;
using System.ComponentModel;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public sealed class AppointmentViewModel
    {
        public AppointmentViewModel()
        {
            this.EndDate = DateTime.Today;
        }

        public Guid Id { get; set; }

        public WorkerViewModel Worker { get; set; }

        [DisplayName("Врачи")]
        public SelectList Workers { get; set; }
        public int SelectedWorkerId { get; set; }

        public PatientViewModel Patient { get; set; }

        public DiseaseOutcomeModel Outcome { get; set; }

        public ExaminationResultModel ExaminationResult { get; set; }

        public DateTime EndDate { get; set; }

        public IList<ServiceResultModel> ServicesResults { get; set; }

        public QuestionnaireAfter75 QuestionnaireAfter75 { get; set; }

        public QuestionnaireTill75ViewModel QuestionnaireTill75 { get; set; }
    }
}
