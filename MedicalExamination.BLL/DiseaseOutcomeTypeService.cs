using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class DiseaseOutcomeTypeService : IDiseaseOutcomeTypeService
    {
        private readonly IGenericRepository<DiseaseOutcomeType> _diseaseOutcomeTypeRepository;

        public DiseaseOutcomeTypeService(IGenericRepository<DiseaseOutcomeType> diseaseOutcomeTypeRepository)
        {
            _diseaseOutcomeTypeRepository = diseaseOutcomeTypeRepository;
        }

        public IEnumerable<DiseaseOutcomeType> GetAllDiseaseOutcomeTypes()
        {
            return _diseaseOutcomeTypeRepository.GetAll().AsEnumerable();
        }

        public DiseaseOutcomeType GetDiseaseOutcomeType(Guid id)
        {
            return _diseaseOutcomeTypeRepository.GetById(id);
        }

        public void CreateDiseaseOutcomeType(DiseaseOutcomeModel diseaseOutcomeModel)
        {
            var diseaseOutcomeType =
                SimpleMapper.Mapper.Map<DiseaseOutcomeModel, DiseaseOutcomeType>(diseaseOutcomeModel);

            _diseaseOutcomeTypeRepository.Insert(diseaseOutcomeType);
        }

        public void UpdateDiseaseOutcomeType(DiseaseOutcomeModel diseaseOutcomeModel)
        {
            var diseaseOutcomeType =
                SimpleMapper.Mapper.Map<DiseaseOutcomeModel, DiseaseOutcomeType>(diseaseOutcomeModel);

            _diseaseOutcomeTypeRepository.Update(diseaseOutcomeType);
        }

        public void DeleteDiseaseOutcomeType(DiseaseOutcomeModel diseaseOutcomeModel)
        {
            var diseaseOutcomeType =
                SimpleMapper.Mapper.Map<DiseaseOutcomeModel, DiseaseOutcomeType>(diseaseOutcomeModel);

            _diseaseOutcomeTypeRepository.Delete(diseaseOutcomeType);
        }
    }
}
