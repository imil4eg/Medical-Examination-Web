using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;
using SimpleMapper;

namespace MedicalExamination.BLL
{
    public sealed class WorkerService : IWorkerService
    {
        private readonly IGenericRepository<Worker> _workerRepository;
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<ProvideService> _provideServiceRepository;
        private readonly IGenericRepository<ServiceType> _serviceRepository;
        private readonly IGenericRepository<Position> _positionRepository;

        public WorkerService(IGenericRepository<Worker> workerRepository, IGenericRepository<Person> personRepository,
            IGenericRepository<ProvideService> provideServiceRepository, IGenericRepository<ServiceType> serviceRepository,
            IGenericRepository<Position> positionRepository)
        {
            _workerRepository = workerRepository;
            _personRepository = personRepository;
            _provideServiceRepository = provideServiceRepository;
            _serviceRepository = serviceRepository;
            _positionRepository = positionRepository;
        }

        public IEnumerable<WorkerModel> GetAllWorkers()
        {
            var workers = _workerRepository.GetAll().ToArray();

            var models = workers.Map<Worker, WorkerModel>().ToArray();
            for (int i = 0; i < models.Length; i++)
            {
                models[i].Person =
                    SimpleMapper.Mapper.Map<Person, PersonModel>(_personRepository.GetById(workers[i].PersonId));

                models[i].Positions = _positionRepository.GetAll().Where(p => p.WorkerId == models[i].PersonId)
                    .Map<Position, PositionModel>();
            }

            return models;
        }

        public WorkerModel GetWorker(int id)
        {
            var model = SimpleMapper.Mapper.Map<Worker, WorkerModel>(_workerRepository.GetById(id));

            return model;
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
