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

        [DisplayName("Врач принимающий случай")]
        public SelectList Workers { get; set; }
        public int WorkerId { get; set; }

        public PatientViewModel Patient { get; set; }

        [DisplayName("Исход случая")]
        public SelectList Outcomes { get; set; }
        public Guid OutcomeId { get; set; }
        
        public ExaminationResultModel ExaminationResult { get; set; }

        public DateTime EndDate { get; set; }

        public IList<ServiceResultViewModel> ServicesResults { get; set; }

        public QuestionnaireAfter75 QuestionnaireAfter75 { get; set; }

        public QuestionnaireTill75ViewModel QuestionnaireTill75 { get; set; }
    }
}
