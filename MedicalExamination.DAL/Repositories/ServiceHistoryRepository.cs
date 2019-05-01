using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="ServiceResult"/>
    /// </summary>
    public sealed class ServiceHistoryRepository : GenericRepository<ServiceResult>
    {
        public ServiceHistoryRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
