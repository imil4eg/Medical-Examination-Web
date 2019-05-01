using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class WorkerService : IWorkerService
    {
        private readonly IGenericRepository<Worker> _workerRepository;
        private readonly IGenericRepository<Person> _personRepository;

        public WorkerService(IGenericRepository<Worker> workerRepository, IGenericRepository<Person> personRepository)
        {
            _workerRepository = workerRepository;
            _personRepository = personRepository;
        }
 
        public IEnumerable<Worker> GetAllWorkers()
        {
            return _workerRepository.GetAll();
        }

        public Worker GetWorker(int id)
        {
            return _workerRepository.GetById(id);
        }

        public void CreateWorker(WorkerModel workerModel)
        {
            var person = SimpleMapper.Mapper.Map<PersonModel, Person>(workerModel.Person);
             person =  _personRepository.Insert(person);

            var worker = SimpleMapper.Mapper.Map<WorkerModel, Worker>(workerModel);
            worker.Person = person;
            worker.PersonId = person.Id;

            _workerRepository.Insert(worker);
        }

        public void UpdateWorker(WorkerModel workerModel)
        {
            var person = SimpleMapper.Mapper.Map<PersonModel, Person>(workerModel.Person);
            _personRepository.Update(person);

            var worker = SimpleMapper.Mapper.Map<WorkerModel, Worker>(workerModel);
            worker.Person = person;
            worker.PersonId = person.Id;

            _workerRepository.Update(worker);
        }

        public void DeleteWorker(WorkerModel workerModel)
        {
            var worker = SimpleMapper.Mapper.Map<WorkerModel, Worker>(workerModel);
            worker.PersonId = worker.PersonId;

            _workerRepository.Delete(worker);
        }

        public void RelateUserToWorker(WorkerModel workerModel)
        {
            var worker = SimpleMapper.Mapper.Map<WorkerModel, Worker>(workerModel);
            var person = SimpleMapper.Mapper.Map<PersonModel, Person>(workerModel.Person);
            worker.PersonId = person.Id;
            worker.Person = person;

            _workerRepository.Update(worker);
        }
    }
}
