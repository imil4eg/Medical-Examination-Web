using System;
using System.Collections.Generic;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="InsuranceCompanyModel"/> entity service implementation
    /// </summary>
    public interface IInsuranceCompanyTypeService
    {
        IEnumerable<InsuranceCompanyModel> GetAllInsuranceCompanies();
        InsuranceCompanyModel GetInsuranceCompany(Guid id);
        void CreateInsuranceCompany(InsuranceCompanyModel insuranceCompanyModel);
        void UpdateInsuranceCompany(InsuranceCompanyModel insuranceCompanyModel);
        void DeleteInsuranceCompany(InsuranceCompanyModel insuranceCompanyModel);
    }
}
