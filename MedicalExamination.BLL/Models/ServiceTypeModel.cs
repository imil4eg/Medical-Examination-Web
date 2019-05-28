using MedicalExamination.Entities;
using System;

namespace MedicalExamination.BLL
{
    public sealed class ServiceTypeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public byte Gender { get; set; }

        public ProcedurePeriodicity Periodicity { get; set; }

        public string AgeRange { get; set; }

        public bool IsIncluded { get; set; }
    }
}
