using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ExaminationResultType"/> entity service implementation
    /// </summary>
    public interface IExaminationResultTypeService
    {
        IEnumerable<ExaminationResultType> GetAllExaminationResultTypes();
        ExaminationResultType GetExaminationResultType(Guid id);
        void CreateExaminationResultType(ExaminationResultModel examinationResultModel);
        void UpdateExaminationResultType(ExaminationResultModel examinationResultModel);
        void DeleteExaminationResultType(ExaminationResultModel examinationResultModel);
    }
}
