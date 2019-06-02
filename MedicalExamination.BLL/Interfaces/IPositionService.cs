using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="Position"/> entity
    /// </summary>
    public interface IPositionService
    {
        IEnumerable<Position> GetAllPositions();
        IEnumerable<Position> GetWorkerPositions(int id);
        IEnumerable<PositionModel> GetWorkersOfSpecifiedPosition(Guid positionId);
        Position GetPosition(Guid id);
        void CreatePosition(PositionModel positionModel);
        void UpdatePosition(PositionModel positionModel);
        void DeletePosition(PositionModel positionModel);
    }
}
