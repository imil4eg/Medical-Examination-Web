using System;
using System.Collections.Generic;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ServiceTypeModel"/> entity service implementation
    /// </summary>
    public interface IServiceTypeService
    {
        IEnumerable<ServiceTypeModel> GetAllAServiceTypes();
        ServiceTypeModel GetServiceType(Guid id);
        void CreateServiceType(ServiceTypeModel serviceTypeModel);
        void UpdateServiceType(ServiceTypeModel serviceTypeModel);
        void DeleteServiceType(ServiceTypeModel serviceTypeModel);
        IEnumerable<ServiceTypeModel> GetAllServicesForPerson(int gender, DateTime birthDate);
    }
}
