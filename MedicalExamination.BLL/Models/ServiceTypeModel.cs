using MedicalExamination.Entities;
using System;

namespace MedicalExamination.BLL
{
    public sealed class ServiceTypeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public GenderOfService Gender { get; set; }

        public string AgeRange { get; set; }

        public bool IsIncluded { get; set; }
    }
}
