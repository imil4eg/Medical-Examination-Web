using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="PassportIssuePlaceType"/> entity service implementation
    /// </summary>
    public interface IPassportIssuePlaceTypeService
    {
        IEnumerable<PassportIssuePlaceModel> GetAllPassportIssuePlaces();
        PassportIssuePlaceModel GetPassportIssuePlace(Guid id);
        void CreatePassportIssuePlace(PassportIssuePlaceModel passportIssuePlaceModel);
        void UpdatePassportIssuePlace(PassportIssuePlaceModel passportIssuePlaceModel);
        void DeletePassportIssuePlace(PassportIssuePlaceModel passportIssuePlaceModel);
    }
}
