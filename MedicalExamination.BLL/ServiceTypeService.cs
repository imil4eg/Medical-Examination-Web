using System;
using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;
using SimpleMapper;

namespace MedicalExamination.BLL
{
    public sealed class ServiceTypeService : IServiceTypeService
    {
        private readonly IGenericRepository<ServiceType> _serviceTypeRepository;

        public ServiceTypeService(IGenericRepository<ServiceType> serviceTypeRepository)
        {
            _serviceTypeRepository = serviceTypeRepository;
        }

        public IEnumerable<ServiceTypeModel> GetAllAServiceTypes()
        {
            var servicesModels = _serviceTypeRepository.GetAll().Map<ServiceType, ServiceTypeModel>();

            return servicesModels;
        }

        public ServiceTypeModel GetServiceType(Guid id)
        {
            var serviceModel =
                SimpleMapper.Mapper.Map<ServiceType, ServiceTypeModel>(_serviceTypeRepository.GetById(id));

            return serviceModel;
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
