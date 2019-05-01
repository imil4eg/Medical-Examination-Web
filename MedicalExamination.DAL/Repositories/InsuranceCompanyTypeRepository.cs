using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="InsuranceCompanyType"/>
    /// </summary>
    public sealed class InsuranceCompanyTypeRepository : GenericRepository<InsuranceCompanyType>
    {
        public InsuranceCompanyTypeRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
