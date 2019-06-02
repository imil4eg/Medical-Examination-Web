using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class ExaminationResultTypeService : IExaminationResultTypeService
    {
        private readonly IGenericRepository<ExaminationResultType> _examinationResultTypeRepository;

        public ExaminationResultTypeService(IGenericRepository<ExaminationResultType> examinationResultTypeRepository)
        {
            _examinationResultTypeRepository = examinationResultTypeRepository;
        }

        public IEnumerable<ExaminationResultType> GetAllExaminationResultTypes()
        {
            return _examinationResultTypeRepository.GetAll().AsEnumerable();
        }

        public ExaminationResultType GetExaminationResultType(Guid id)
        {
            return _examinationResultTypeRepository.GetById(id);
        }

        public void CreateExaminationResultType(ExaminationResultModel examinationResultModel)
        {
            var examinationResultType =
                SimpleMapper.Mapper.Map<ExaminationResultModel, ExaminationResultType>(examinationResultModel);

            _examinationResultTypeRepository.Insert(examinationResultType);
        }

        public void UpdateExaminationResultType(ExaminationResultModel examinationResultModel)
        {
            var examinationResultType =
                SimpleMapper.Mapper.Map<ExaminationResultModel, ExaminationResultType>(examinationResultModel);

            _examinationResultTypeRepository.Update(examinationResultType);
        }

        public void DeleteExaminationResultType(ExaminationResultModel examinationResultModel)
        {
            var examinationResultType =
                SimpleMapper.Mapper.Map<ExaminationResultModel, ExaminationResultType>(examinationResultModel);

            _examinationResultTypeRepository.Delete(examinationResultType);
        }
    }
}
