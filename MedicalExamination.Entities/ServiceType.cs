namespace MedicalExamination.Entities
{
    public sealed class ServiceType : BaseTypeEntity
    {
        public string Code { get; set; }

        public GenderOfService Gender { get; set; }

        public ProcedurePeriodicity Periodicity { get; set; }

        public string AgeRange { get; set; }

        public bool IsIncluded { get; set; }
    }
}
