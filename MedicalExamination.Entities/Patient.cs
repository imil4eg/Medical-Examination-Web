using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public sealed class Patient
    {
        [Key]
        public int PersonId { get; set; }
        [ForeignKey("PersonId")]
        public Person Person { get; set; }

        [Required]
        public string InsuranceNumber { get; set; }

        [Required]
        public Guid InsuranceCompanyId { get; set; }
        [ForeignKey("InsuranceCompanyId")]
        public InsuranceCompanyType InsuranceCompany { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
