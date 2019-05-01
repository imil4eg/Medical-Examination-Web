using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="DiseaseOutcomeType"/>
    /// </summary>
    public sealed class DiseaseOutcomeTypeRepository : GenericRepository<DiseaseOutcomeType>
    {
        public DiseaseOutcomeTypeRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
