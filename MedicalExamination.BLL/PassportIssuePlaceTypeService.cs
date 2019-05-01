using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class PassportIssuePlaceTypeService : IPassportIssuePlaceType
    {
        private readonly IGenericRepository<PassportIssuePlaceType> _passportIssuePlaceTypeRepository;

        public PassportIssuePlaceTypeService(IGenericRepository<PassportIssuePlaceType> passportIssuePlaceTypeRepository)
        {
            _passportIssuePlaceTypeRepository = passportIssuePlaceTypeRepository;
        }

        public IEnumerable<PassportIssuePlaceType> GetAllPassportIssuePlaceTypes()
        {
            return _passportIssuePlaceTypeRepository.GetAll();
        }

        public PassportIssuePlaceType GetPassportIssuePlaceType(int id)
        {
            return _passportIssuePlaceTypeRepository.GetById(id);
        }

        public void CreatePassportIssuePlaceType(PassportIssuePlaceType passportIssuePlaceType)
        {
            _passportIssuePlaceTypeRepository.Insert(passportIssuePlaceType);
        }

        public void UpdatePassportIssuePlaceType(PassportIssuePlaceType passportIssuePlaceType)
        {
            _passportIssuePlaceTypeRepository.Update(passportIssuePlaceType);
        }

        public void DeletePassportIssuePlaceType(PassportIssuePlaceType passportIssuePlaceType)
        {
            _passportIssuePlaceTypeRepository.Delete(passportIssuePlaceType);
        }
    }
}
