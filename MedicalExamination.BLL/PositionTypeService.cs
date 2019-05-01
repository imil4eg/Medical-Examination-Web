using System;
using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class PositionTypeService : IPositionTypeService
    {
        private readonly IGenericRepository<PositionType> _positionTypeRepository;

        public PositionTypeService(IGenericRepository<PositionType> positionTypeRepository)
        {
            _positionTypeRepository = positionTypeRepository;
        }

        public IEnumerable<PositionType> GetAllPositionTypes()
        {
            return _positionTypeRepository.GetAll();
        }

        public PositionType GetPositionType(Guid id)
        {
            return _positionTypeRepository.GetById(id);
        }

        public void CreatePositionType(PositionTypeModel positionTypeModel)
        {
            var positionType = SimpleMapper.Mapper.Map<PositionTypeModel, PositionType>(positionTypeModel);

            _positionTypeRepository.Insert(positionType);
        }

        public void UpdatePositionType(PositionTypeModel positionTypeModel)
        {
            var positionType = SimpleMapper.Mapper.Map<PositionTypeModel, PositionType>(positionTypeModel);

            _positionTypeRepository.Update(positionType);
        }

        public void DeletePositionType(PositionTypeModel positionTypeModel)
        {
            var positionType = SimpleMapper.Mapper.Map<PositionTypeModel, PositionType>(positionTypeModel);

            _positionTypeRepository.Delete(positionType);
        }
    }
}
