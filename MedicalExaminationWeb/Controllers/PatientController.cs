using System;
using System.Collections.Generic;
using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IActionResult Patients()
        {
            var patients = _patientService.GetAllPatients();

            var patientModels = new List<PatientModel>();
            foreach (var patient in patients)
            {
                var patientModel = new PatientModel();
                patientModel = SimpleMapper.Mapper.Map<MedicalExamination.BLL.PatientModel, PatientModel>(patient);
                patientModel.Person =
                    SimpleMapper.Mapper.Map<MedicalExamination.BLL.PersonModel, PersonModel>(patient.Person);

                patientModels.Add(patientModel);
            }

            return View(patientModels);
        }

        [HttpPost]
        [Route("getpatient")]
        public ActionResult GetPatient(int patientId)
        {
            var patient = _patientService.GetPatient(patientId);

            return Ok(patient);
        }

        [HttpPost]
        [Route("insert")]
        public ActionResult InsertPatient([FromBody] PatientModel model)
        {
            var patientModel = new MedicalExamination.BLL.PatientModel();
            patientModel = SimpleMapper.Mapper.Map<PatientModel, MedicalExamination.BLL.PatientModel>(model);
            patientModel.Person =
                SimpleMapper.Mapper.Map<PersonModel, MedicalExamination.BLL.PersonModel>(model.Person);

            _patientService.CreatePatient(patientModel);

            return Ok();
        }

        [HttpGet]
        public IActionResult CreatePatient()
        {
            var patientModel = new PatientModel();

            return View(patientModel);
        }

        [HttpPost]
        public IActionResult CreatePatient(PatientModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return View();
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdatePatient([FromBody] PatientModel model)
        {
            try
            {
                var patientModel = new MedicalExamination.BLL.PatientModel();
                patientModel = SimpleMapper.Mapper.Map<PatientModel, MedicalExamination.BLL.PatientModel>(model);
                patientModel.Person =
                    SimpleMapper.Mapper.Map<PersonModel, MedicalExamination.BLL.PersonModel>(model.Person);

                _patientService.UpdatePatient(patientModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeletePatient([FromBody] PatientModel model)
        {
            try
            {
                var patientModel = new MedicalExamination.BLL.PatientModel
                {
                    PersonId = model.PersonId
                };

                _patientService.DeletePatient(patientModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
