using System;
using System.Linq;
using MedicalExamination.BLL;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public ActionResult GetAppointments()
        {
            return Ok(_appointmentService.GetAllAppointments());
        }

        [HttpGet]
        [Route("getappointment")]
        public ActionResult GetAppointment(Guid id)
        {
            return Ok(this._appointmentService.GetAppointment(id));
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CreateAppointment(AppointmentModel model)
        {
            try
            {
                var appointment =
                    SimpleMapper.Mapper.Map<AppointmentModel, MedicalExamination.BLL.AppointmentModel>(model);
                appointment.Patient =
                    SimpleMapper.Mapper.Map<PatientModel, MedicalExamination.BLL.PatientModel>(model.Patient);
                appointment.Worker =
                    SimpleMapper.Mapper.Map<WorkerModel, MedicalExamination.BLL.WorkerModel>(model.Worker);
                appointment.ServicesResults = model.ServicesResults.Select(sr =>
                    SimpleMapper.Mapper.Map<ServiceResultModel, MedicalExamination.BLL.ServiceResultModel>(sr));

                if (model.QuestionnaireAfter75 != null)
                {
                    appointment.QuestionnaireAfter75 = model.QuestionnaireAfter75;
                }
                else
                {
                    appointment.QuestionnaireTill75 = model.QuestionnaireTill75;
                }

                this._appointmentService.CreateAppointment(appointment);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public ActionResult UpdateAppointment(AppointmentModel model)
        {
            try
            {
                var appointment =
                    SimpleMapper.Mapper.Map<AppointmentModel, MedicalExamination.BLL.AppointmentModel>(model);
                appointment.Patient =
                    SimpleMapper.Mapper.Map<PatientModel, MedicalExamination.BLL.PatientModel>(model.Patient);
                appointment.Worker =
                    SimpleMapper.Mapper.Map<WorkerModel, MedicalExamination.BLL.WorkerModel>(model.Worker);
                appointment.ServicesResults = model.ServicesResults.Select(sr =>
                    SimpleMapper.Mapper.Map<ServiceResultModel, MedicalExamination.BLL.ServiceResultModel>(sr));

                if (model.QuestionnaireAfter75 != null)
                {
                    appointment.QuestionnaireAfter75 = model.QuestionnaireAfter75;
                }
                else
                {
                    appointment.QuestionnaireTill75 = model.QuestionnaireTill75;
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
        [Route("delete")]
        public ActionResult DeleteAppointment(AppointmentModel model)
        {
            try
            {
                var appointment =
                    SimpleMapper.Mapper.Map<AppointmentModel, MedicalExamination.BLL.AppointmentModel>(model);
                appointment.Patient =
                    SimpleMapper.Mapper.Map<PatientModel, MedicalExamination.BLL.PatientModel>(model.Patient);
                appointment.Worker =
                    SimpleMapper.Mapper.Map<WorkerModel, MedicalExamination.BLL.WorkerModel>(model.Worker);
                appointment.ServicesResults = model.ServicesResults.Select(sr =>
                    SimpleMapper.Mapper.Map<ServiceResultModel, MedicalExamination.BLL.ServiceResultModel>(sr));

                if (model.QuestionnaireAfter75 != null)
                {
                    appointment.QuestionnaireAfter75 = model.QuestionnaireAfter75;
                }
                else
                {
                    appointment.QuestionnaireTill75 = model.QuestionnaireTill75;
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
