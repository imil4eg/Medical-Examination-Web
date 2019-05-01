using System;

namespace MedicalExamination.BLL
{
    public sealed class PatientDiagnosisModel
    {
        public Guid Id { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid DiagnosisId { get; set; }

        public bool IsMain { get; set; }
    }
}
