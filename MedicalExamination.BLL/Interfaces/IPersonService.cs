using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="Person"/> entity service implementation
    /// </summary>
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPerson(int id);
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }
}
