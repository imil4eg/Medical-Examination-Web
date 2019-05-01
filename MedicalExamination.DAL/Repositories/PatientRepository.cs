using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="Patient"/>
    /// </summary>
    public sealed class PatientRepository : GenericRepository<Patient>
    {
        public PatientRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
