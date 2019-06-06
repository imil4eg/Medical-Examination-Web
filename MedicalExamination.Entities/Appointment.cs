using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public class Appointment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int WorkerId { get; set; }
        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }

        [Required]
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }

        //[Required]
        //public Guid ExaminationResultId { get; set; }
        //[ForeignKey("ExaminationResultId")]
        //public ExaminationResultType ExaminationResult { get; set; }

        [Required]
        public Guid DiseaseOutcomeTypeId { get; set; }
        [ForeignKey("DiseaseOutcomeTypeId")]
        public virtual DiseaseOutcomeType DiseaseOutcomeType { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
