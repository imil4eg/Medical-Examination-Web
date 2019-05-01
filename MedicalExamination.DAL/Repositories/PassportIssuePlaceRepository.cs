using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="PassportIssuePlaceType"/>
    /// </summary>
    public sealed class PassportIssuePlaceRepository : GenericRepository<PassportIssuePlaceType>
    {
        public PassportIssuePlaceRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
