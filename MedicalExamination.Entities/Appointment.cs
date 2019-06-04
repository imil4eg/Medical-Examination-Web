using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public sealed class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public Worker Worker { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        //[Required]
        //public Guid ExaminationResultId { get; set; }
        //[ForeignKey("ExaminationResultId")]
        //public ExaminationResultType ExaminationResult { get; set; }

        [Required]
        public Guid DiseaseOutcomeTypeId { get; set; }
        [ForeignKey("DiseaseOutcomeTypeId")]
        public DiseaseOutcomeType DiseaseOutcomeType { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
