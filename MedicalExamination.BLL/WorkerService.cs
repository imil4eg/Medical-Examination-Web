using System;
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
        private readonly IPositionService _positionService;
        private readonly IPositionTypeService _positionTypeService;
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly IGenericRepository<ServiceResult> _serviceResultRepository;
        private readonly IGenericRepository<ApplicationUser> _userRepository;

        public WorkerService(IGenericRepository<Worker> workerRepository, IGenericRepository<Person> personRepository,
            IGenericRepository<ProvideService> provideServiceRepository,
            IGenericRepository<ServiceType> serviceRepository,
            IGenericRepository<Position> positionRepository, IPositionService positionService,
            IPositionTypeService positionTypeService, IGenericRepository<Appointment> appointmentRepository,
            IGenericRepository<ServiceResult> serviceResultRepository,
            IGenericRepository<ApplicationUser> userRepository)
        {
            _workerRepository = workerRepository;
            _personRepository = personRepository;
            _provideServiceRepository = provideServiceRepository;
            _serviceRepository = serviceRepository;
            _positionRepository = positionRepository;
            _positionService = positionService;
            _positionTypeService = positionTypeService;
            _appointmentRepository = appointmentRepository;
            _serviceResultRepository = serviceResultRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<WorkerModel> GetAllWorkers()
        {
            var workers = _workerRepository.GetAll().ToArray();

            var models = workers.Map<Worker, WorkerModel>().ToArray();

            foreach (var workerModel in models)
            {
                workerModel.Person =
                    SimpleMapper.Mapper.Map<Person, PersonModel>(_personRepository.GetById(workerModel.PersonId));

                var positions = _positionRepository.GetAll();
                positions = positions.Where(p => p.WorkerId == workerModel.PersonId);

                workerModel.Positions = positions.AsEnumerable().Map<Position, PositionModel>();

                workerModel.PositionTypes =
                    _positionTypeService.GetPositionTypesByPositionIds(workerModel.Positions.Select(s => s.PositionId));
            }

            return models;
        }

        public WorkerModel GetWorker(int id)
        {
            var worker = _workerRepository.GetById(id);
            worker.Person = _personRepository.GetById(id);

            var model = SimpleMapper.Mapper.Map<Worker, WorkerModel>(worker);
            model.Person = SimpleMapper.Mapper.Map<Person, PersonModel>(worker.Person);
            model.Position = _positionService.GetWorkerPositions(id).First().PositionId;

            return model;
        }

        public int CreateWorker(WorkerModel workerModel)
        {
            var person = SimpleMapper.Mapper.Map<PersonModel, Person>(workerModel.Person);
             person =  _personRepository.Insert(person);

            var worker = SimpleMapper.Mapper.Map<WorkerModel, Worker>(workerModel);
            worker.Person = person;
            worker.PersonId = person.Id;

            var createdWorker = _workerRepository.Insert(worker);

            var position = new PositionModel {PositionId = workerModel.Position, WorkerId = person.Id};

            _positionService.CreatePosition(position);

            return createdWorker.PersonId;
        }

        public void UpdateWorker(WorkerModel workerModel)
        {
            var person = SimpleMapper.Mapper.Map<PersonModel, Person>(workerModel.Person);
            person.PassportIssuePlaceId = workerModel.Person.PassportIssuePlaceId;
            _personRepository.Update(person);

            var worker = SimpleMapper.Mapper.Map<WorkerModel, Worker>(workerModel);
            worker.Person = person;
            worker.PersonId = person.Id;

            _workerRepository.Update(worker);

            var position = _positionService.GetWorkerPositions(workerModel.PersonId).First();

            if (position.PositionId == workerModel.Position)
                return;

            var updatePosition = new PositionModel {Id =  position.Id, PositionId = workerModel.Position, WorkerId = workerModel.PersonId};
            _positionService.UpdatePosition(updatePosition);
        }

        public void DeleteWorker(WorkerModel workerModel)
        {
            var workerAppointments = _appointmentRepository.GetAll().Where(a => a.WorkerId == workerModel.PersonId);

            if(workerAppointments.Any())
                throw new Exception("Ошибка при удалении: Данный врач участвует в случаях диспансеризации. Удалите их или замените врача на другого, прежде чем удалять врача.");

            var workerDoneServices = _serviceResultRepository.GetAll().Where(sr => sr.WorkerId == workerModel.PersonId);

            if(workerDoneServices.Any())
                throw new Exception("Ошибка при удалении: Данный врач провел услугу в рамках случая. Удалите случай или замените врача в случае, прежде чем удалять врача.");

            var workerUser = _userRepository.GetAll().Where(u => u.WorkerId == workerModel.PersonId);

            if(workerUser.Any())
                throw new Exception("Ошибка при удалении: К данному врачу привязан пользователь. Удалите пользователя прежде чем удалять врача.");

            var worker = _workerRepository.GetById(workerModel.PersonId);

            var workerPositions = _positionRepository.GetAll().Where(p => p.WorkerId == worker.PersonId);

            if (workerPositions.Any())
            {
                _positionRepository.Delete(workerPositions);
            }

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
