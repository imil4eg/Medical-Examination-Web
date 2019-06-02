using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;
using SimpleMapper;

namespace MedicalExamination.BLL
{
    public sealed class InsuranceCompanyTypeService : IInsuranceCompanyTypeService
    {
        private readonly IGenericRepository<InsuranceCompanyType> _insuranceCompanyTypeRepository;

        public InsuranceCompanyTypeService(IGenericRepository<InsuranceCompanyType> insuranceCompanyTypeRepository)
        {
            _insuranceCompanyTypeRepository = insuranceCompanyTypeRepository;
        }

        public IEnumerable<InsuranceCompanyModel> GetAllInsuranceCompanies()
        {
            var insuranceCompanyModels = _insuranceCompanyTypeRepository.GetAll().AsEnumerable()
                .Map<InsuranceCompanyType, InsuranceCompanyModel>();

            return insuranceCompanyModels;
        }

        public InsuranceCompanyModel GetInsuranceCompany(Guid id)
        {
            var insuranceCompany = _insuranceCompanyTypeRepository.GetById(id);

            var insuranceCompanyModel =
                SimpleMapper.Mapper.Map<InsuranceCompanyType, InsuranceCompanyModel>(insuranceCompany);

            return insuranceCompanyModel;
        }

        public void CreateInsuranceCompany(InsuranceCompanyModel insuranceCompanyModel)
        {
           
            var insuranceCompanyType =
                SimpleMapper.Mapper.Map<InsuranceCompanyModel, InsuranceCompanyType>(insuranceCompanyModel);

            _insuranceCompanyTypeRepository.Insert(insuranceCompanyType);
        }

        public void UpdateInsuranceCompany(InsuranceCompanyModel insuranceCompanyModel)
        {
            var insuranceCompanyType =
                SimpleMapper.Mapper.Map<InsuranceCompanyModel, InsuranceCompanyType>(insuranceCompanyModel);

            _insuranceCompanyTypeRepository.Update(insuranceCompanyType);
        }

        public void DeleteInsuranceCompany(InsuranceCompanyModel insuranceCompanyModel)
        {
            var insuranceCompanyType =
                SimpleMapper.Mapper.Map<InsuranceCompanyModel, InsuranceCompanyType>(insuranceCompanyModel);

            _insuranceCompanyTypeRepository.Delete(insuranceCompanyType);
        }
    }
}
