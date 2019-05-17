using System;
using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public sealed class InsuranceCompanyViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Название компании")]
        public string Name { get; set; }
    }
}
