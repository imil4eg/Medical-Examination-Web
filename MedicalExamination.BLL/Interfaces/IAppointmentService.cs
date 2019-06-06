using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="Appointment"/> entity service implementation
    /// </summary>
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAllAppointments();
        AppointmentModel GetAppointment(Guid id);
        void CreateAppointment(AppointmentModel appointmentModel);
        void UpdateAppointment(AppointmentModel appointmentModel);
        void DeleteAppointment(AppointmentModel appointmentModel);
    }
}
