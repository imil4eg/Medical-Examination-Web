using System;
using System.ComponentModel;

namespace MedicalExaminationWeb
{
    public sealed class ExaminationResultModel
    {
        public Guid Id { get; set; }
        
        [DisplayName("Название результата")]
        public string Name { get; set; }
    }
}
