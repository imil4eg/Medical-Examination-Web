using System;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class PatientModel
    {
        [DataMember(Name = "person_id")]
        public int PersonId { get; set; }

        [DataMember(Name = "insurance_number")]
        public string InsuranceNumber { get; set; }
        
        [DataMember(Name = "insurance_company_id")]
        public Guid InsuranceCompanyId { get; set; }

        [DataMember(Name = "person")]
        public PersonModel Person { get; set; }
    }
}
