using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="ServiceType"/>
    /// </summary>
    public sealed class ServiceTypeRepository : GenericRepository<ServiceType>
    {
        public ServiceTypeRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
