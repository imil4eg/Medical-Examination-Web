using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="PassportIssuePlaceType"/> entity service implementation
    /// </summary>
    public interface IPassportIssuePlaceType
    {
        IEnumerable<PassportIssuePlaceType> GetAllPassportIssuePlaceTypes();
        PassportIssuePlaceType GetPassportIssuePlaceType(int id);
        void CreatePassportIssuePlaceType(PassportIssuePlaceType passportIssuePlaceType);
        void UpdatePassportIssuePlaceType(PassportIssuePlaceType passportIssuePlaceType);
        void DeletePassportIssuePlaceType(PassportIssuePlaceType passportIssuePlaceType);
    }
}
