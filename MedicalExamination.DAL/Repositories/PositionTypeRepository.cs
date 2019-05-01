using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="PositionType"/>
    /// </summary>
    public sealed class PositionTypeRepository : GenericRepository<PositionType>
    {
        public PositionTypeRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
