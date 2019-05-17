using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="Position"/>
    /// </summary>
    public class PositionRepository : GenericRepository<Position>
    {
        public PositionRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
