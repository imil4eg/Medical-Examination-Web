using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ServiceType"/> entity service implementation
    /// </summary>
    public interface IServiceTypeService
    {
        IEnumerable<ServiceType> GetAllAServiceTypes();
        ServiceType GetServiceType(Guid id);
        void CreateServiceType(ServiceTypeModel serviceTypeModel);
        void UpdateServiceType(ServiceTypeModel serviceTypeModel);
        void DeleteServiceType(ServiceTypeModel serviceTypeModel);
    }
}
