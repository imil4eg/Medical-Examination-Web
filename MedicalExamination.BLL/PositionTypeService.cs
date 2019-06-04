using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;
using SimpleMapper;

namespace MedicalExamination.BLL
{
    public sealed class PositionTypeService : IPositionTypeService
    {
        private readonly IGenericRepository<PositionType> _positionTypeRepository;
        private readonly IGenericRepository<ProvideService> _provideServiceRepository;
        private readonly IGenericRepository<ServiceType> _serviceTypeRepository;
        private readonly IProvideServiceService _provideServiceService;
        private readonly IPositionService _positionService;

        public PositionTypeService(IGenericRepository<PositionType> positionTypeRepository,
            IGenericRepository<ProvideService> provideServiceRepository,
            IGenericRepository<ServiceType> serviceTypeRepository, IProvideServiceService provideServiceService, IPositionService positionService)
        {
            _positionTypeRepository = positionTypeRepository;
            _provideServiceRepository = provideServiceRepository;
            _serviceTypeRepository = serviceTypeRepository;
            _provideServiceService = provideServiceService;
            _positionService = positionService;
        }

        public IEnumerable<PositionTypeModel> GetAllPositionTypes()
        {
            var positionTypes = _positionTypeRepository.GetAll().AsEnumerable().Map<PositionType, PositionTypeModel>();

            return positionTypes;
        }

        public PositionTypeModel GetPositionType(Guid id)
        {
            var position =
                SimpleMapper.Mapper.Map<PositionType, PositionTypeModel>(_positionTypeRepository.GetAll()
                    .FirstOrDefault(pt => pt.Id == id));
            position.ProvideServices = _provideServiceRepository.GetAll().Where(ps => ps.PositionId == position.Id).AsEnumerable()
                .Map<ProvideService, ProvideServiceModel>();

            var serviceTypes = _serviceTypeRepository.GetAll().ToArray();
            position.ServiceTypes = serviceTypes.Where(st => position.ProvideServices.Any(ps => ps.ServiceId == st.Id))
                .Map<ServiceType, ServiceTypeModel>();

            return position;
        }

        public IEnumerable<PositionTypeModel> GetPositionTypesByPositionIds(IEnumerable<Guid> positionIds)
        {
            var positionTypes = _positionTypeRepository.GetAll();
            positionTypes = positionTypes.Where(p => positionIds.Any(id => id == p.Id));

            return positionTypes.AsEnumerable().Map<PositionType, PositionTypeModel>();
        }

        public void CreatePositionType(PositionTypeModel positionTypeModel)
        {
            var positionType = SimpleMapper.Mapper.Map<PositionTypeModel, PositionType>(positionTypeModel);

            var createdPositionType = _positionTypeRepository.Insert(positionType);

            var provideServices = positionTypeModel.ServiceTypes.Select(serviceType =>
                new ProvideService {PositionId = createdPositionType.Id, ServiceId = serviceType.Id}).ToList();

            _provideServiceRepository.Insert(provideServices);
        }

        public void UpdatePositionType(PositionTypeModel positionTypeModel)
        {
            var positionType = SimpleMapper.Mapper.Map<PositionTypeModel, PositionType>(positionTypeModel);
            _positionTypeRepository.Update(positionType);

            var existingProvideServices = _provideServiceService.GetProvideServicesOfPosition(positionTypeModel.Id);

            var unselectedExistingProvideService = existingProvideServices.Where(eps =>
                positionTypeModel.ServiceTypes.Any(st => st.Id != eps.ServiceId));
            //.Select(ps => new ProvideService {Id = ps.Id, PositionId = ps.PositionId, ServiceId = ps.ServiceId}).ToArray();

            var provideServices = _provideServiceService.GetAllProvideServices().AsEnumerable();
            var unselectedProvideServices = provideServices
                .Where(p => unselectedExistingProvideService.Any(ps => ps.Id == p.Id)).ToArray();

            if (unselectedProvideServices.Length > 0)
            {
                _provideServiceRepository.Delete(unselectedProvideServices);
            }

            var notExistingProvideServices =
                positionTypeModel.ServiceTypes.Where(st => existingProvideServices.All(pd => pd.ServiceId != st.Id));

            var newProvideServices = notExistingProvideServices.Select(serviceType =>
                new ProvideService {PositionId = positionTypeModel.Id, ServiceId = serviceType.Id}).ToList();

            if (newProvideServices.Count > 0)
            {
                _provideServiceRepository.Insert(newProvideServices);
            }
        }

        public void DeletePositionType(PositionTypeModel positionTypeModel)
        {
            var positionType = SimpleMapper.Mapper.Map<PositionTypeModel, PositionType>(positionTypeModel);

            var workerInThisPosition = _positionService.GetWorkersOfSpecifiedPosition(positionTypeModel.Id).ToArray();

            if (workerInThisPosition.Length > 0)
            {
                throw new Exception("Данная позиция уже используется врачами. Замените позиции и потом пробуйте снова.");
            }

            var provideServices = _provideServiceService.GetProvideServicesOfPosition(positionTypeModel.Id);

            _positionTypeRepository.Delete(positionType);

            _provideServiceService.DeleteProvideServices(provideServices);
        }
    }
}
