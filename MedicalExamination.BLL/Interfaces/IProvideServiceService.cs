using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ProvideService"/> entity service implementation
    /// </summary>
    public interface IProvideServiceService
    {
        IEnumerable<ProvideService> GetAllProvideServices();
        IEnumerable<ProvideServiceModel> GetProvideServicesOfPosition(Guid positionId);
        ProvideService GetProvideService(Guid id);
        void CreateProvideService(ProvideServiceModel provideServiceModel);
        void UpdateProvideService(ProvideServiceModel provideServiceModel);
        void DeleteProvideService(ProvideServiceModel provideServiceModel);
        void DeleteProvideServices(IEnumerable<ProvideServiceModel> provideServiceModels);
    }
}
