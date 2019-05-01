using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="ExaminationResultType"/>
    /// </summary>
    public sealed class ExaminationResultTypeRepository : GenericRepository<ExaminationResultType>
    {
        public ExaminationResultTypeRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
