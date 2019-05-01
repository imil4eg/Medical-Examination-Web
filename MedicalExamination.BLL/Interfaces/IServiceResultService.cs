using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ServiceResult"/> entity service implementation
    /// </summary>
    public interface IServiceResultService
    {
        IEnumerable<ServiceResult> GetAllServiceResults();
        ServiceResult GetServiceResult(Guid id);
        void CreateServiceResult(ServiceResultModel serviceResult);
        void UpdateServiceResult(ServiceResultModel serviceResult);
        void DeleteServiceResult(ServiceResultModel serviceResult);
    }
}
