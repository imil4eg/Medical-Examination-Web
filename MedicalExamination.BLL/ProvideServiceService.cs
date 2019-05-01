using System;
using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class ProvideServiceService : IProvideServiceService
    {
        private readonly IGenericRepository<ProvideService> _provideServiceRepository;

        public ProvideServiceService(IGenericRepository<ProvideService> provideServiceRepository)
        {
            _provideServiceRepository = provideServiceRepository;
        }

        public IEnumerable<ProvideService> GetAllProvideServices()
        {
            return _provideServiceRepository.GetAll();
        }

        public ProvideService GetProvideService(Guid id)
        {
            return _provideServiceRepository.GetById(id);
        }

        public void CreateProvideService(ProvideServiceModel provideServiceModel)
        {
            var provideService = SimpleMapper.Mapper.Map<ProvideServiceModel, ProvideService>(provideServiceModel);

            _provideServiceRepository.Insert(provideService);
        }

        public void UpdateProvideService(ProvideServiceModel provideServiceModel)
        {
            var provideService = SimpleMapper.Mapper.Map<ProvideServiceModel, ProvideService>(provideServiceModel);

            _provideServiceRepository.Update(provideService);
        }

        public void DeleteProvideService(ProvideServiceModel provideServiceModel)
        {
            var provideService = SimpleMapper.Mapper.Map<ProvideServiceModel, ProvideService>(provideServiceModel);

            _provideServiceRepository.Delete(provideService);
        }
    }
}
