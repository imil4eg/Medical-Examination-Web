using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class PatientViewModel 
    {
        public int PersonId { get; set; }

        [DisplayName("Номер страховки")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым")]
        public string InsuranceNumber { get; set; }

        public InsuranceCompanyViewModel InsuranceCompany { get; set; }

        [DisplayName("Страховая компания")]
        public SelectList InsuranceCompanies { get; set; }
        public Guid SelectedInsuranceCompanyId { get; set; }

        [DataMember(Name = "person")]
        public PersonViewModel Person { get; set; }

        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
    }
}
