using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.BLL;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IWorkerService _workerService;
        private readonly IServiceTypeService _serviceTypeService;
        private readonly IDiseaseOutcomeTypeService _diseaseOutcomeTypeService;

        public AppointmentController(IAppointmentService appointmentService, IPatientService patientService,
            IWorkerService workerService, IServiceTypeService serviceTypeService,
            IDiseaseOutcomeTypeService diseaseOutcomeTypeService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _workerService = workerService;
            _serviceTypeService = serviceTypeService;
            _diseaseOutcomeTypeService = diseaseOutcomeTypeService;
        }

        [HttpGet]
        public ActionResult GetAppointments()
        {
            return Ok(_appointmentService.GetAllAppointments());
        }

        [HttpGet]
        public ActionResult GetAppointment(Guid appointmentId)
        {
            return Ok(this._appointmentService.GetAppointment(appointmentId));
        }

        [HttpGet]
        public ActionResult CreateAppointment(int patientId)
        {
            var patient = _patientService.GetPatient(patientId);

            var patientModel =
                SimpleMapper.Mapper.Map<PatientModel, PatientViewModel>(_patientService.GetPatient(patientId));
            patientModel.Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(patient.Person);

            var appointmentModel = new AppointmentViewModel();
            appointmentModel.Patient = patientModel;

            var outcomes = _diseaseOutcomeTypeService.GetAllDiseaseOutcomeTypes();
            appointmentModel.Outcomes  = new SelectList(outcomes, "Id", "Name");
            appointmentModel.OutcomeId = outcomes.First().Id;

            var workers = _workerService.GetAllWorkers().ToArray();

            var workerModels = workers.Map<WorkerModel, WorkerViewModel>().ToArray();
            for (int i = 0; i < workerModels.Length; i++)
            {
                workerModels[i].Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(workers[i].Person);
                workerModels[i].FullName =
                    string.Format(
                        $"{workers[i].Person.LastName} {workers[i].Person.FirstName} {workers[i].Person.MiddleName}");
                workerModels[i].PersonId = workers[i].PersonId;
            }

            appointmentModel.Workers = new SelectList(workerModels, "PersonId", "FullName");
            appointmentModel.WorkerId = workerModels[0].PersonId;

            var serviceTypes =
                _serviceTypeService.GetAllServicesForPerson((int) patientModel.Person.Gender, patientModel.Person.BirthDate)
                    .Map<ServiceTypeModel, ServiceViewModel>();

            var serviceResults = serviceTypes.Select(serviceType => new ServiceResultModel
            {
                Service = serviceType, ServiceTypeId = serviceType.Id,
                Workers = new SelectList(workerModels, "PersonId", "FullName", workerModels[0].PersonId)
            }).ToList();

            appointmentModel.ServicesResults = serviceResults;

                appointmentModel.QuestionnaireTill75 = new QuestionnaireTill75ViewModel
                {
                    QuestionSeven = EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionSevenAnswers)),
                    QuestionTwentyOne = EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentyOneAnswers)),
                    QuestionTwentyFive = EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentyFiveAnswers)),
                    QuestionTwentySix = EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentySixAnswers)),
                    QuestionTwentySeven = EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentySevenAnswers))
                };
            

            return View(appointmentModel);
        }

        [HttpPost]
        public ActionResult CreateAppointment(AppointmentViewModel model)
        {
            var appointment =
                SimpleMapper.Mapper.Map<AppointmentViewModel, MedicalExamination.BLL.AppointmentModel>(model);
            appointment.Patient =
                SimpleMapper.Mapper.Map<PatientViewModel, MedicalExamination.BLL.PatientModel>(model.Patient);
            appointment.Worker = new WorkerModel {PersonId = model.WorkerId};
            appointment.ServicesResults = model.ServicesResults.Select(sr =>
                SimpleMapper.Mapper.Map<ServiceResultModel, MedicalExamination.BLL.ServiceResultModel>(sr));    
            appointment.QuestionnaireTill75 =
                SimpleMapper.Mapper.Map<QuestionnaireTill75ViewModel, QuestionnaireTill75>(model.QuestionnaireTill75);

            appointment.Outcome = new MedicalExamination.BLL.DiseaseOutcomeModel {Id = model.OutcomeId};
            appointment.Worker = new WorkerModel {PersonId = model.WorkerId};

            this._appointmentService.CreateAppointment(appointment);

            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateAppointment(AppointmentViewModel model)
        {
            try
            {
                var appointment =
                    SimpleMapper.Mapper.Map<AppointmentViewModel, MedicalExamination.BLL.AppointmentModel>(model);
                appointment.Patient =
                    SimpleMapper.Mapper.Map<PatientViewModel, MedicalExamination.BLL.PatientModel>(model.Patient);
                appointment.Worker =
                    SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model.Worker);
                appointment.ServicesResults = model.ServicesResults.Select(sr =>
                    SimpleMapper.Mapper.Map<ServiceResultModel, MedicalExamination.BLL.ServiceResultModel>(sr));

                if (model.QuestionnaireAfter75 != null)
                {
                    appointment.QuestionnaireAfter75 = model.QuestionnaireAfter75;
                }
                else
                {
                    //appointment.QuestionnaireTill75 = model.QuestionnaireTill75;
                }

                this._appointmentService.UpdateAppointment(appointment);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult DeleteAppointment(AppointmentViewModel model)
        {
            try
            {
                var appointment =
                    SimpleMapper.Mapper.Map<AppointmentViewModel, MedicalExamination.BLL.AppointmentModel>(model);
                appointment.Patient =
                    SimpleMapper.Mapper.Map<PatientViewModel, MedicalExamination.BLL.PatientModel>(model.Patient);
                appointment.Worker =
                    SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model.Worker);
                appointment.ServicesResults = model.ServicesResults.Select(sr =>
                    SimpleMapper.Mapper.Map<ServiceResultModel, MedicalExamination.BLL.ServiceResultModel>(sr));

                if (model.QuestionnaireAfter75 != null)
                {
                    appointment.QuestionnaireAfter75 = model.QuestionnaireAfter75;
                }
                else
                {
                    //appointment.QuestionnaireTill75 = model.QuestionnaireTill75;
                }

                this._appointmentService.DeleteAppointment(appointment);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
