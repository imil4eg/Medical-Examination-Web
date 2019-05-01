using System;
using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class ServiceTypeService : IServiceTypeService
    {
        private readonly IGenericRepository<ServiceType> _serviceTypeRepository;

        public ServiceTypeService(IGenericRepository<ServiceType> serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public IEnumerable<ServiceType> GetAllAServiceTypes()
        {
            return _serviceTypeRepository.GetAll();
        }

        public ServiceType GetServiceType(Guid id)
        {
            return _serviceTypeRepository.GetById(id);
        }

        public void CreateServiceType(ServiceTypeModel serviceTypeModel)
        {
            var serviceType = SimpleMapper.Mapper.Map<ServiceTypeModel, ServiceType>(serviceTypeModel);

            _serviceTypeRepository.Insert(serviceType);
        }

        public void UpdateServiceType(ServiceTypeModel serviceTypeModel)
        {

            var serviceType = SimpleMapper.Mapper.Map<ServiceTypeModel, ServiceType>(serviceTypeModel);

            _serviceTypeRepository.Update(serviceType);
        }

        public void DeleteServiceType(ServiceTypeModel serviceTypeModel)
        {
            var serviceType = SimpleMapper.Mapper.Map<ServiceTypeModel, ServiceType>(serviceTypeModel);

            _serviceTypeRepository.Delete(serviceType);
        }
    }
}
