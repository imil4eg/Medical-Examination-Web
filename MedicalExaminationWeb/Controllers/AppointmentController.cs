using System;
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
        private readonly IQuestionnaireTill75Service _questionnaireTill75Service;

        public AppointmentController(IAppointmentService appointmentService, IPatientService patientService,
            IWorkerService workerService, IServiceTypeService serviceTypeService,
            IDiseaseOutcomeTypeService diseaseOutcomeTypeService,
            IQuestionnaireTill75Service questionnaireTill75Service)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _workerService = workerService;
            _serviceTypeService = serviceTypeService;
            _diseaseOutcomeTypeService = diseaseOutcomeTypeService;
            _questionnaireTill75Service = questionnaireTill75Service;
        }

        [HttpGet]
        public ActionResult GetAppointments()
        {
            return Ok(_appointmentService.GetAllAppointments());
        }

        [HttpGet]
        public ActionResult GetAppointment(Guid appointmentId)
        {
            var appointment = this._appointmentService.GetAppointment(appointmentId);

            var appointmentViewModel = SimpleMapper.Mapper.Map<AppointmentModel, AppointmentViewModel>(appointment);

            appointmentViewModel.OutcomeId = appointment.Outcome.Id;
            appointmentViewModel.Outcomes = this.FullFillOutcomes();

            appointmentViewModel.Patient = new PatientViewModel
            {
                Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(appointment.Patient.Person),
                PersonId = appointment.Patient.PersonId
            };

            appointmentViewModel.QuestionnaireTill75 =
                SimpleMapper.Mapper.Map<QuestionnaireTill75, QuestionnaireTill75ViewModel>(appointment
                    .QuestionnaireTill75);

            appointmentViewModel.Worker = new WorkerViewModel
            {
                PersonId = appointment.Worker.PersonId,
                Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(appointment.Worker.Person)
            };

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

            appointmentViewModel.Workers = new SelectList(workerModels, "PersonId", "FullName");
            appointmentViewModel.WorkerId = appointment.Worker.PersonId;

            var serviceTypes =
                _serviceTypeService
                    .GetAllAServiceTypes()
                    .Map<ServiceTypeModel, ServiceViewModel>();

            appointmentViewModel.ServicesResults = appointment.ServicesResults.Select(serviceType => new ServiceResultViewModel
            {
                Id = serviceType.Id,
                Service = serviceTypes.FirstOrDefault(st => st.Id == serviceType.ServiceTypeId),
                ServiceTypeId = serviceType.ServiceTypeId,
                Result = serviceType.Result,
                TubeNumber = serviceType.TubeNumber,
                AppointmentId = appointmentId,
                Workers = new SelectList(workerModels, "PersonId", "FullName", workerModels[0].PersonId),
                WorkerId = serviceType.WorkerId
            }).ToList();

            appointmentViewModel.QuestionnaireTill75.QuestionSeven =
                EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionSevenAnswers));
            appointmentViewModel.QuestionnaireTill75.SelectedQuestionSevenAnswer =
                (int)appointment.QuestionnaireTill75.QuestionSeven;

            appointmentViewModel.QuestionnaireTill75.QuestionTwentyOne =
                EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentyOneAnswers));
            appointmentViewModel.QuestionnaireTill75.SelectedQuestionTwentyOneAnswer =
                appointment.QuestionnaireTill75.QuestionTwentyOne ? 1 : 0;

            appointmentViewModel.QuestionnaireTill75.QuestionTwentyFive =
                EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentyFiveAnswers));
            appointmentViewModel.QuestionnaireTill75.SelectedQuestionTwentyFiveAnswer =
                (int) appointment.QuestionnaireTill75.QuestionTwentyFive;

            appointmentViewModel.QuestionnaireTill75.QuestionTwentySix =
                EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentySixAnswers));
            appointmentViewModel.QuestionnaireTill75.SelectedQuestionTwentySixAnswer =
                (int) appointment.QuestionnaireTill75.QuestionTwentySix;

            appointmentViewModel.QuestionnaireTill75.QuestionTwentySeven =
                EnumDisplayNamePicker.GetDisplayNames(typeof(QuestionTwentySevenAnswers));
            appointmentViewModel.QuestionnaireTill75.SelectedQuestionTwentySevenAnswer =
                (int) appointment.QuestionnaireTill75.QuestionTwentySeven;

            return View("Appointment", appointmentViewModel);
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
            appointmentModel.Outcomes = new SelectList(outcomes, "Id", "Name");
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
                _serviceTypeService
                    .GetAllServicesForPerson((int) patientModel.Person.Gender, patientModel.Person.BirthDate)
                    .Map<ServiceTypeModel, ServiceViewModel>();

            var serviceResults = serviceTypes.Select(serviceType => new ServiceResultViewModel
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
                SimpleMapper.Mapper.Map<ServiceResultViewModel, MedicalExamination.BLL.ServiceResultModel>(sr));    

            appointment.QuestionnaireTill75 =
                SimpleMapper.Mapper.Map<QuestionnaireTill75ViewModel, QuestionnaireTill75>(model.QuestionnaireTill75);
            appointment.QuestionnaireTill75.QuestionSeven =
                (MedicalExamination.Entities.QuestionSevenAnswers) model.QuestionnaireTill75
                    .SelectedQuestionSevenAnswer;

            appointment.QuestionnaireTill75.QuestionTwentyOne =
                model.QuestionnaireTill75.SelectedQuestionTwentyOneAnswer == 1 ? true : false;

            appointment.QuestionnaireTill75.QuestionTwentyFive =
                (MedicalExamination.Entities.QuestionTwentyFiveAnswers) model
                    .QuestionnaireTill75.SelectedQuestionTwentyFiveAnswer;

            appointment.QuestionnaireTill75.QuestionTwentySix =
                (MedicalExamination.Entities.QuestionTwentySixAnswers) model
                    .QuestionnaireTill75.SelectedQuestionTwentySixAnswer;

            appointment.QuestionnaireTill75.QuestionTwentySeven =
                (MedicalExamination.QuestionTwentySevenAnswers) model.QuestionnaireTill75
                    .SelectedQuestionTwentySevenAnswer;

            appointment.Outcome = new MedicalExamination.BLL.DiseaseOutcomeModel {Id = model.OutcomeId};
            appointment.Worker = new WorkerModel {PersonId = model.WorkerId};

            this._appointmentService.CreateAppointment(appointment);

            return Json(Url.Action("GetPatient", "Patient", new { patientId = model.Patient.PersonId }));
        }

        [HttpPost]
        public ActionResult UpdateAppointment(AppointmentViewModel model)
        {
            var appointment = SimpleMapper.Mapper.Map<AppointmentViewModel, AppointmentModel>(model);
            appointment.Patient = SimpleMapper.Mapper.Map<PatientViewModel, PatientModel>(model.Patient);
            appointment.Worker = new WorkerModel {PersonId = model.WorkerId};
            appointment.ServicesResults = model.ServicesResults.Select(sr =>
                SimpleMapper.Mapper.Map<ServiceResultViewModel, ServiceResultModel>(sr));

            appointment.QuestionnaireTill75 =
                SimpleMapper.Mapper.Map<QuestionnaireTill75ViewModel, QuestionnaireTill75>(model.QuestionnaireTill75);
            appointment.QuestionnaireTill75.QuestionSeven =
                (MedicalExamination.Entities.QuestionSevenAnswers)model.QuestionnaireTill75
                    .SelectedQuestionSevenAnswer;

            appointment.QuestionnaireTill75.QuestionTwentyOne =
                model.QuestionnaireTill75.SelectedQuestionTwentyOneAnswer == 1 ? true : false;

            appointment.QuestionnaireTill75.QuestionTwentyFive =
                (MedicalExamination.Entities.QuestionTwentyFiveAnswers)model
                    .QuestionnaireTill75.SelectedQuestionTwentyFiveAnswer;

            appointment.QuestionnaireTill75.QuestionTwentySix =
                (MedicalExamination.Entities.QuestionTwentySixAnswers)model
                    .QuestionnaireTill75.SelectedQuestionTwentySixAnswer;

            appointment.QuestionnaireTill75.QuestionTwentySeven =
                (MedicalExamination.QuestionTwentySevenAnswers)model.QuestionnaireTill75
                    .SelectedQuestionTwentySevenAnswer;

            appointment.Outcome = new MedicalExamination.BLL.DiseaseOutcomeModel {Id = model.OutcomeId};
            appointment.Worker = new WorkerModel {PersonId = model.WorkerId};

            this._appointmentService.UpdateAppointment(appointment);

            return Json(Url.Action("GetPatient","Patient", new { patientId = appointment.Patient.PersonId}));
        }

        [HttpGet]
        public ActionResult DeleteAppointment(Guid appointmentId)
        {
            var appointmentModel = new AppointmentModel() {Id = appointmentId};

            this._appointmentService.DeleteAppointment(appointmentModel);

            return RedirectToAction("Patients", "Patient");
        }

        [NonAction]
        private SelectList FullFillOutcomes()
        {
            var diseaseOutcomes = _diseaseOutcomeTypeService.GetAllDiseaseOutcomeTypes();

            return new SelectList(diseaseOutcomes, "Id", "Name");
        }
    }
}
