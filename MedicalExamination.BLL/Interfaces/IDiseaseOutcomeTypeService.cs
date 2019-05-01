using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="DiseaseOutcomeType"/> entity service implementation
    /// </summary>
    public interface IDiseaseOutcomeTypeService
    {
        IEnumerable<DiseaseOutcomeType> GetAllDiseaseOutcomeTypes();
        DiseaseOutcomeType GetDiseaseOutcomeType(Guid id);
        void CreateDiseaseOutcomeType(DiseaseOutcomeModel diseaseOutcomeModel);
        void UpdateDiseaseOutcomeType(DiseaseOutcomeModel diseaseOutcomeModel);
        void DeleteDiseaseOutcomeType(DiseaseOutcomeModel diseaseOutcomeModel);
    }
}
