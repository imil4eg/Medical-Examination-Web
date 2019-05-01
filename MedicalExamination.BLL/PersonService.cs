using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class PersonService : IPersonService
    {
        private readonly IGenericRepository<Person> _personRepository;

        public PersonService(IGenericRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _personRepository.GetAll();
        }

        public Person GetPerson(int id)
        {
            return _personRepository.GetById(id);
        }

        public void CreatePerson(Person person)
        {
            _personRepository.Insert(person);
        }

        public void UpdatePerson(Person person)
        {
            _personRepository.Update(person);
        }

        public void DeletePerson(Person person)
        {
            _personRepository.Delete(person);
        }
    }
}
