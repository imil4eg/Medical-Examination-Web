using System;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("/api/[controller]")]
    public sealed class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult GetPatients()
        {
            var patients = _patientService.GetAllPatients();

            return Ok(patients);
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
