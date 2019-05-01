﻿using System;

namespace MedicalExamination.BLL
{
    public sealed class ServiceResultModel
    {
        public Guid Id { get; set; }

        public Guid AppointmentId { get; set; }

        public Guid ServiceTypeId { get; set; }

        public string Result { get; set; }

        public string TubeNumber { get; set; }

        public string Description { get; set; }
    }
}
