using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [DisplayName("Рабочий")]
        public SelectList Workers { get; set; }
        public int WorkerId { get; set; }
    }
}
