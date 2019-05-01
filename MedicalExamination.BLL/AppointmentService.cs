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

        public AppointmentService(IGenericRepository<Appointment> appointmentRepository, IGenericRepository<QuestionnaireAfter75> questionnaireAfter75Repository,
            IGenericRepository<QuestionnaireTill75> questionnaireTill75Repository, IGenericRepository<ServiceResult> serviceResultRepository)
        {
            _appointmentRepository = appointmentRepository;
            this._questionnaireAfter75Repository = questionnaireAfter75Repository;
            this._questionnaireTill75Repository = questionnaireTill75Repository;
            this._serviceResultRepository = serviceResultRepository;
        }

        // TODO: realize logic of appointment

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetAppointment(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        public void CreateAppointment(AppointmentModel appointmentModel)
        {
            var appointment = new Appointment();
            appointment.PatientId = appointmentModel.Patient.PersonId;
            appointment.WorkerId = appointment.WorkerId;
            appointment.EndDate = appointmentModel.EndDate;
            appointment.ExaminationResultId = appointmentModel.ExaminationResult.Id;
            appointment.DiseaseOutcomeTypeId = appointmentModel.Outcome.Id;

            Appointment createdAppointment = _appointmentRepository.Insert(appointment);

            if (DateTime.Today.AddYears(-appointmentModel.Patient.Person.BirthDate.Year).Year > 75)
            {
                QuestionnaireAfter75 questionnaireAfter75 = appointmentModel.QuestionnaireAfter75;
                questionnaireAfter75.AppointmentId = createdAppointment.Id;

                this._questionnaireAfter75Repository.Insert(questionnaireAfter75);
            }
            else
            {
                QuestionnaireTill75 questionnaireTill75 = appointmentModel.QuestionnaireTill75;
                questionnaireTill75.AppointmentId = createdAppointment.Id;

                this._questionnaireTill75Repository.Insert(questionnaireTill75);
            }

            var examinationResults = appointmentModel.ServicesResults.Select(serviceResult =>
                SimpleMapper.Mapper.Map<ServiceResultModel, ServiceResult>(serviceResult));

            _serviceResultRepository.Insert(examinationResults);
            //_appointmentRepository.Insert(appointment);
        }

        public void UpdateAppointment(AppointmentModel appointmentModel)
        {
            //_appointmentRepository.Update(appointment);
        }

        public void DeleteAppointment(AppointmentModel appointmentModel)
        {
            //_appointmentRepository.Delete(appointment);
        }
    }
}
