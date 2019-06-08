using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;
using SimpleMapper;

namespace MedicalExamination.BLL
{
    public sealed class ServiceResultService : IServiceResultService
    {
        private readonly IGenericRepository<ServiceResult> _serviceResultRepository;

        public ServiceResultService(IGenericRepository<ServiceResult> serviceResultRepository)
        {
            _serviceResultRepository = serviceResultRepository;
        }

        public IEnumerable<ServiceResult> GetAllServiceResults()
        {
            return _serviceResultRepository.GetAll().AsEnumerable();
        }

        public IEnumerable<ServiceResultModel> GetServiceResultsOfAppointment(Guid appointmentId)
        {
            return _serviceResultRepository.GetAll().AsEnumerable().Where(r => r.AppointmentId == appointmentId)
                .Map<ServiceResult, ServiceResultModel>();
        }

        public ServiceResult GetServiceResult(Guid id)
        {
            return _serviceResultRepository.GetById(id);
        }

        public void CreateServiceResult(ServiceResultModel serviceResultModel)
        {
            var serviceResult = SimpleMapper.Mapper.Map<ServiceResultModel, ServiceResult>(serviceResultModel);

            _serviceResultRepository.Insert(serviceResult);
        }

        public void UpdateServiceResult(ServiceResultModel serviceResultModel)
        {
            var serviceResult = _serviceResultRepository.GetById(serviceResultModel.Id);
            serviceResult.Result = serviceResultModel.Result;
            serviceResult.TubeNumber = serviceResultModel.TubeNumber;
            serviceResult.WorkerId = serviceResultModel.WorkerId;

            //var serviceResult = SimpleMapper.Mapper.Map<ServiceResultModel, ServiceResult>(serviceResultModel);

            _serviceResultRepository.Update(serviceResult);
        }

        public void DeleteServiceResult(ServiceResultModel serviceResultModel)
        {
            var serviceResult = SimpleMapper.Mapper.Map<ServiceResultModel, ServiceResult>(serviceResultModel);

            _serviceResultRepository.Delete(serviceResult);
        }
    }
}
