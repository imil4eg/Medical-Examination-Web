using System;
using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public class ServiceResultModel
    {
        public Guid Id { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid ServiceTypeId { get; set; }

        public ServiceViewModel Service { get; set; }

        [DisplayName("Результат")]
        public string Result { get; set; }

        [DisplayName("Номер пробирки")]
        public string TubeNumber { get; set; }

        public string Description { get; set; }
    }
}
