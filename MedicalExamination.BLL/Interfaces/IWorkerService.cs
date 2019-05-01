using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="Worker"/> entity service implementation
    /// </summary>
    public interface IWorkerService
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorker(int id);
        void CreateWorker(WorkerModel workerModel);
        void UpdateWorker(WorkerModel workerModel);
        void DeleteWorker(WorkerModel workerModel);
        void RelateUserToWorker(WorkerModel workerModel);
    }
}
