using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="PositionType"/> entity service implementation
    /// </summary>
    public interface IPositionTypeService
    {
        IEnumerable<PositionTypeModel> GetAllPositionTypes();
        PositionTypeModel GetPositionType(Guid id);
        IEnumerable<PositionTypeModel> GetPositionTypesByPositionIds(IEnumerable<Guid> positionId);
        void CreatePositionType(PositionTypeModel positionType);
        void UpdatePositionType(PositionTypeModel positionType);
        void DeletePositionType(PositionTypeModel positionType);
    }
}
