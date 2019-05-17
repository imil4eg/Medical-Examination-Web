﻿using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class PatientViewModel 
    {
        public int PersonId { get; set; }

        [DisplayName("Номер страховки")]
        public string InsuranceNumber { get; set; }

        public InsuranceCompanyViewModel InsuranceCompany { get; set; }

        [DisplayName("Страховая компания")]
        public SelectList InsuranceCompanies { get; set; }
        public Guid SelectedInsuranceCompanyId { get; set; }

        [DataMember(Name = "person")]
        public PersonViewModel Person { get; set; }
    }
}