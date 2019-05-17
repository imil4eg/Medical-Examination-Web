using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="ProvideService"/>
    /// </summary>
    public class ProvideServiceRepository : GenericRepository<ProvideService>
    {
        public ProvideServiceRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
