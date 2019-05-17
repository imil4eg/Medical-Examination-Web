﻿using System;
using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public class PassportIssuePlaceModel
    {
        public Guid Id { get; set; }

        [DisplayName("Место выдачи паспорта")]
        public string Name { get; set; }
    }
}
