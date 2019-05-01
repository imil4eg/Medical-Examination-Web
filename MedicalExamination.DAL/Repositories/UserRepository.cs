using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="ApplicationUser"/>
    /// </summary>
    public sealed class UserRepository : GenericRepository<ApplicationUser>
    {
        public UserRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
