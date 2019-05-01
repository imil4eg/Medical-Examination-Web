using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="InsuranceCompanyType"/> entity service implementation
    /// </summary>
    public interface IInsuranceCompanyTypeService
    {
        IEnumerable<InsuranceCompanyType> GetAllInsuranceCompanyTypes();
        InsuranceCompanyType GetInsuranceCompanyType(Guid id);
        void CreateInsuranceCompanyType(InsuranceCompanyModel insuranceCompanyModel);
        void UpdateInsuranceCompanyType(InsuranceCompanyModel insuranceCompanyModel);
        void DeleteInsuranceCompanyType(InsuranceCompanyModel insuranceCompanyModel);
    }
}
