using MedicalExamination.Entities;

namespace MedicalExamination.DAL
{
    /// <summary>
    /// Repository for <see cref="Appointment"/>
    /// </summary>
    public sealed class AppointmentRepository : GenericRepository<Appointment>
    {
        public AppointmentRepository(MedicalExaminationContext context) : base(context)
        {
        }
    }
}
