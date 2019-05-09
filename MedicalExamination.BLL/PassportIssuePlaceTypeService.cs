using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class PassportIssuePlaceTypeService : IPassportIssuePlaceTypeService
    {
        private readonly IGenericRepository<PassportIssuePlaceType> _passportIssuePlaceTypeRepository;

        public PassportIssuePlaceTypeService(IGenericRepository<PassportIssuePlaceType> passportIssuePlaceTypeRepository)
        {
            _passportIssuePlaceTypeRepository = passportIssuePlaceTypeRepository;
        }

        public IEnumerable<PassportIssuePlaceModel> GetAllPassportIssuePlaces()
        {
            var passportIssuePlaces = _passportIssuePlaceTypeRepository.GetAll();

            return passportIssuePlaces.Select(passportIssuePlaceType =>
                SimpleMapper.Mapper.Map<PassportIssuePlaceType, PassportIssuePlaceModel>(passportIssuePlaceType));
        }

        public PassportIssuePlaceModel GetPassportIssuePlace(Guid id)
        {
            var passportIssuePlace = _passportIssuePlaceTypeRepository.GetById(id);

            var passportIssuePlaceModel =
                SimpleMapper.Mapper.Map<PassportIssuePlaceType, PassportIssuePlaceModel>(passportIssuePlace);

            return passportIssuePlaceModel;
        }

        public void CreatePassportIssuePlace(PassportIssuePlaceModel passportIssuePlaceModel)
        {
            var passportIssuePlace =
                SimpleMapper.Mapper.Map<PassportIssuePlaceModel, PassportIssuePlaceType>(passportIssuePlaceModel);

            _passportIssuePlaceTypeRepository.Insert(passportIssuePlace);
        }

        public void UpdatePassportIssuePlace(PassportIssuePlaceModel passportIssuePlaceModel)
        {
            var passportIssuePlace =
                SimpleMapper.Mapper.Map<PassportIssuePlaceModel, PassportIssuePlaceType>(passportIssuePlaceModel);


            _passportIssuePlaceTypeRepository.Update(passportIssuePlace);
        }

        public void DeletePassportIssuePlace(PassportIssuePlaceModel passportIssuePlaceModel)
        {
            var passportIssuePlace =
                SimpleMapper.Mapper.Map<PassportIssuePlaceModel, PassportIssuePlaceType>(passportIssuePlaceModel);

            _passportIssuePlaceTypeRepository.Delete(passportIssuePlace);
        }
    }
}
