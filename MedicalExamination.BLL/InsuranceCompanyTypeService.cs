using System;
using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class InsuranceCompanyTypeService : IInsuranceCompanyTypeService
    {
        private readonly IGenericRepository<InsuranceCompanyType> _insuranceCompanyTypeRepository;

        public InsuranceCompanyTypeService(IGenericRepository<InsuranceCompanyType> insuranceCompanyTypeRepository)
        {
            _insuranceCompanyTypeRepository = insuranceCompanyTypeRepository;
        }

        public IEnumerable<InsuranceCompanyType> GetAllInsuranceCompanyTypes()
        {
            return _insuranceCompanyTypeRepository.GetAll();
        }

        public InsuranceCompanyType GetInsuranceCompanyType(Guid id)
        {
            return _insuranceCompanyTypeRepository.GetById(id);
        }

        public void CreateInsuranceCompanyType(InsuranceCompanyModel insuranceCompanyModel)
        {
            var insuranceCompanyType =
                SimpleMapper.Mapper.Map<InsuranceCompanyModel, InsuranceCompanyType>(insuranceCompanyModel);

            _insuranceCompanyTypeRepository.Insert(insuranceCompanyType);
        }

        public void UpdateInsuranceCompanyType(InsuranceCompanyModel insuranceCompanyModel)
        {
            var insuranceCompanyType =
                SimpleMapper.Mapper.Map<InsuranceCompanyModel, InsuranceCompanyType>(insuranceCompanyModel);

            _insuranceCompanyTypeRepository.Update(insuranceCompanyType);
        }

        public void DeleteInsuranceCompanyType(InsuranceCompanyModel insuranceCompanyModel)
        {
            var insuranceCompanyType =
                SimpleMapper.Mapper.Map<InsuranceCompanyModel, InsuranceCompanyType>(insuranceCompanyModel);

            _insuranceCompanyTypeRepository.Delete(insuranceCompanyType);
        }
    }
}
