using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IPassportIssuePlaceTypeService _passportIssuePlaceService;
        private readonly IInsuranceCompanyTypeService _insuranceCompanyService;

        public PatientController(IPatientService patientService,
            IPassportIssuePlaceTypeService passportIssuePlaceService,
            IInsuranceCompanyTypeService insuranceCompanyService)
        {
            _patientService = patientService;
            _passportIssuePlaceService = passportIssuePlaceService;
            _insuranceCompanyService = insuranceCompanyService;
        }

        [HttpGet]
        public IActionResult Patients()
        {
            var patients = _patientService.GetAllPatients();

            var patientModels = new List<PatientViewModel>();
            foreach (var patient in patients)
            {
                var patientModel = new PatientViewModel();
                patientModel = SimpleMapper.Mapper.Map<MedicalExamination.BLL.PatientModel, PatientViewModel>(patient);
                patientModel.Person =
                    SimpleMapper.Mapper.Map<MedicalExamination.BLL.PersonModel, PersonViewModel>(patient.Person);

                patientModels.Add(patientModel);
            }

            return View(patientModels);
        }

        [HttpGet]
        public ActionResult GetPatient(int patientId)
        {
            var patient = _patientService.GetPatient(patientId);

            var patientModel = SimpleMapper.Mapper.Map<MedicalExamination.BLL.PatientModel, PatientViewModel>(patient);

            patientModel.Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(patient.Person);

            this.FullFillSelectLists(patientModel);

            patientModel.SelectedInsuranceCompanyId = patient.InsuranceCompanyId;
            patientModel.Person.SelectedPassportIssuePlaceId = patient.Person.PassportIssuePlaceId;

            return View("PatientProfile", patientModel);
        }

        [HttpGet]
        public IActionResult CreatePatient()
        {
            var patientModel = new PatientViewModel
            {
                Person = new PersonViewModel()
            };

            this.FullFillSelectLists(patientModel);

            return View(patientModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePatient(PatientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                this.FullFillSelectLists(model);

                return View(model);
            }


            var patientModel =
                SimpleMapper.Mapper.Map<PatientViewModel, MedicalExamination.BLL.PatientModel>(model);
            patientModel.InsuranceCompanyId = model.SelectedInsuranceCompanyId;
            patientModel.Person =
                SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person);
            patientModel.Person.PassportIssuePlaceId = model.Person.SelectedPassportIssuePlaceId;

            _patientService.CreatePatient(patientModel);

            return RedirectToAction("Patients");
        }

        [HttpPost]
        public ActionResult UpdatePatient(PatientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                this.FullFillSelectLists(model);

                return View("PatientProfile", model);
            }

            var patientModel = SimpleMapper.Mapper.Map<PatientViewModel, MedicalExamination.BLL.PatientModel>(model);
            patientModel.Person =
                SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Person);

            _patientService.UpdatePatient(patientModel);

            return RedirectToAction("Patients");
        }

        [NonAction]
        public void FullFillSelectLists(PatientViewModel patientModel)
        {
            var passportIssuePlaceModels = _passportIssuePlaceService.GetAllPassportIssuePlaces()
                .Map<MedicalExamination.BLL.PassportIssuePlaceModel, PassportIssuePlaceModel>().ToArray();

            patientModel.Person.PassportIssuePlaces =
                new SelectList(passportIssuePlaceModels, "Id", "Name", passportIssuePlaceModels[0].Id);

            var insuranceCompaniesModels = _insuranceCompanyService.GetAllInsuranceCompanies()
                .Map<MedicalExamination.BLL.InsuranceCompanyModel, InsuranceCompanyViewModel>().ToArray();

            patientModel.InsuranceCompanies =
                new SelectList(insuranceCompaniesModels, "Id", "Name", insuranceCompaniesModels[0].Id);
        }
    }
}
