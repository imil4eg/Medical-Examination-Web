using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="ApplicationRole"/>
    /// </summary>
    public sealed class RoleRepository : GenericRepository<ApplicationRole>
    {
        public RoleRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
