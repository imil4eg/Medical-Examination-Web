using System;
using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public sealed class DiseaseOutcomeModel
    {
        public Guid Id { get; set; }

        [DisplayName("Название исхода")]
        public string Name { get; set; }
    }
}
