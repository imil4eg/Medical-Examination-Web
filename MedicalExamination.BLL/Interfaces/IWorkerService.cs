using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="Worker"/> entity service implementation
    /// </summary>
    public interface IWorkerService
    {
        IEnumerable<WorkerModel> GetAllWorkers();
        WorkerModel GetWorker(int id);
        int CreateWorker(WorkerModel workerModel);
        void UpdateWorker(WorkerModel workerModel);
        void DeleteWorker(WorkerModel workerModel);
        void RelateUserToWorker(WorkerModel workerModel);
    }
}
