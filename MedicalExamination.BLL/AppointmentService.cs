using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Class to data access layer for <see cref="Appointment"/> entity
    /// </summary>
    public sealed class AppointmentService : IAppointmentService
    {
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly IGenericRepository<QuestionnaireAfter75> _questionnaireAfter75Repository;
        private readonly IGenericRepository<QuestionnaireTill75> _questionnaireTill75Repository;
        private readonly IGenericRepository<ServiceResult> _serviceResultRepository;
        private readonly IGenericRepository<Patient> _patientRepository;
        private readonly IGenericRepository<Worker> _workerRepository;
        private readonly IPersonService _personService;
        private readonly IWorkerService _workerService;
        private readonly IServiceResultService _serviceResultService;
        private readonly IDiseaseOutcomeTypeService _diseaseOutcomeTypeService;
        private readonly IPatientService _patientService;
        private readonly IQuestionnaireTill75Service _questionnaireTill75Service;

        public AppointmentService(IGenericRepository<Appointment> appointmentRepository,
            IGenericRepository<QuestionnaireAfter75> questionnaireAfter75Repository,
            IGenericRepository<QuestionnaireTill75> questionnaireTill75Repository,
            IGenericRepository<ServiceResult> serviceResultRepository, IPersonService personService,
            IWorkerService workerService, IServiceResultService serviceResultService,
            IDiseaseOutcomeTypeService diseaseOutcomeTypeService,
            IPatientService patientService,
            IGenericRepository<Patient> patientRepository,
            IGenericRepository<Worker> workerRepository,
            IQuestionnaireTill75Service questionnaireTill75Service)
        {
            _appointmentRepository = appointmentRepository;
            this._questionnaireAfter75Repository = questionnaireAfter75Repository;
            this._questionnaireTill75Repository = questionnaireTill75Repository;
            this._serviceResultRepository = serviceResultRepository;
            _personService = personService;
            _workerService = workerService;
            _serviceResultService = serviceResultService;
            _diseaseOutcomeTypeService = diseaseOutcomeTypeService;
            _patientService = patientService;
            _patientRepository = patientRepository;
            _workerRepository = workerRepository;
            _questionnaireTill75Service = questionnaireTill75Service;
        }

        // TODO: realize logic of appointment

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public AppointmentModel GetAppointment(Guid id)
        {
            var appointment = _appointmentRepository.GetById(id);

            var appointmentModel = SimpleMapper.Mapper.Map<Appointment, AppointmentModel>(appointment);

            appointmentModel.Patient = new PatientModel
            {
                PersonId = appointment.PatientId,
                Person = SimpleMapper.Mapper.Map<Person, PersonModel>(_personService.GetPerson(appointment.PatientId))
            };

            appointmentModel.Worker = _workerService.GetWorker(appointment.WorkerId);
            appointmentModel.Outcome =
                SimpleMapper.Mapper.Map<DiseaseOutcomeType, DiseaseOutcomeModel>(
                    _diseaseOutcomeTypeService.GetDiseaseOutcomeType(appointment.DiseaseOutcomeTypeId));
            
            appointmentModel.QuestionnaireTill75 = _questionnaireTill75Repository.GetById(appointment.Id);

            appointmentModel.ServicesResults = _serviceResultService.GetServiceResultsOfAppointment(appointment.Id);

            return appointmentModel;
        }

        public void CreateAppointment(AppointmentModel appointmentModel)
        {
            var appointment = new Appointment{Id = Guid.NewGuid()};

            appointment.Patient = _patientRepository.GetById(appointmentModel.Patient.PersonId);
            appointment.PatientId = appointment.Patient.PersonId;

            appointment.Worker = _workerRepository.GetById(appointmentModel.Worker.PersonId);
            appointment.WorkerId = appointment.Worker.PersonId;
            
            //appointment.PatientId = appointmentModel.Patient.PersonId;
            appointment.EndDate = DateTime.Today;//appointmentModel.EndDate;
            //appointment.ExaminationResultId = appointmentModel.ExaminationResult.Id;
            appointment.DiseaseOutcomeTypeId = appointmentModel.Outcome.Id;
            //appointment.WorkerId = appointmentModel.Worker.PersonId;

            Appointment createdAppointment = _appointmentRepository.Insert(appointment);

                QuestionnaireTill75 questionnaireTill75 = appointmentModel.QuestionnaireTill75;
                questionnaireTill75.AppointmentId = createdAppointment.Id;

                this._questionnaireTill75Repository.Insert(questionnaireTill75);

            var examinationResults = (from appointmentModelServicesResult in appointmentModel.ServicesResults
            let worker = _workerRepository.GetById(appointmentModelServicesResult.WorkerId)
            select new ServiceResult
            {
                AppointmentId = createdAppointment.Id,
                ServiceTypeId = appointmentModelServicesResult.ServiceTypeId,
                Result = appointmentModelServicesResult.Result,
                TubeNumber = appointmentModelServicesResult.TubeNumber,
                WorkerId = worker.PersonId,
                Worker = worker
            }).ToList();

            //var examinationResults = appointmentModel.ServicesResults.Select(serviceResult =>
            //    new ServiceResult
            //    {
            //        AppointmentId = createdAppointment.Id, ServiceTypeId = serviceResult.ServiceTypeId,
            //        Result = serviceResult.Result, TubeNumber = serviceResult.TubeNumber,
            //        WorkerId = serviceResult.WorkerId, Description = serviceResult.Description
            //    });

            _serviceResultRepository.Insert(examinationResults);
            //_appointmentRepository.Insert(appointment);
        }

        public void UpdateAppointment(AppointmentModel appointmentModel)
        {
            var appointment = _appointmentRepository.GetById(appointmentModel.Id);
            appointment.DiseaseOutcomeTypeId = appointmentModel.Outcome.Id;
            appointment.EndDate = appointmentModel.EndDate;
            appointment.WorkerId = appointmentModel.Worker.PersonId;

            _appointmentRepository.Update(appointment);

            foreach (var serviceResultModel in appointmentModel.ServicesResults)
            {
                _serviceResultService.UpdateServiceResult(serviceResultModel);
            }

            appointmentModel.QuestionnaireTill75.AppointmentId = appointment.Id;

            _questionnaireTill75Service.UpdateQuestionnaire(appointmentModel.QuestionnaireTill75);

            //_questionnaireTill75Repository.Update(appointmentModel.QuestionnaireTill75);

            //_appointmentRepository.Update(appointment);
        }

        public void DeleteAppointment(AppointmentModel appointmentModel)
        {
            //_appointmentRepository.Delete(appointment);
        }
    }
}
