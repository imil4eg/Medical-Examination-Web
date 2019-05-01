using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class PositionService : IPositionService
    {
        private readonly IGenericRepository<Position> _positionRepository;

        public PositionService(IGenericRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public IEnumerable<Position> GetAllPositions()
        {
            return _positionRepository.GetAll();
        }

        public Position GetPosition(Guid id)
        {
            return _positionRepository.GetById(id);
        }

        public IEnumerable<Position> GetWorkerPositions(int workerId)
        {
            return _positionRepository.GetAll().Where(p => p.WorkerId == workerId);
        }

        public void CreatePosition(PositionModel positionModel)
        {
            var position = SimpleMapper.Mapper.Map<PositionModel, Position>(positionModel);

            var workerPositions = this.GetWorkerPositions(position.WorkerId);

            if (workerPositions.Any(wp => wp.PositionId == position.PositionId))
            {
                throw new Exception("Worker already contains that position.");
            }

            _positionRepository.Insert(position);
        }

        public void UpdatePosition(PositionModel positionModel)
        {
            var position = SimpleMapper.Mapper.Map<PositionModel, Position>(positionModel);

            _positionRepository.Update(position);
        }

        public void DeletePosition(PositionModel positionModel)
        {
            var position = SimpleMapper.Mapper.Map<PositionModel, Position>(positionModel);

            _positionRepository.Delete(position);
        }
    }
}
