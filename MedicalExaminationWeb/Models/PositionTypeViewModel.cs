using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public sealed class PositionTypeViewModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }    

        public IEnumerable<ProvideServiceViewModel> ProvideServices { get; set; }
        
        [DisplayName("Проводимые услуги")]
        public MultiSelectList ServiceTypes { get; set; }
        public IEnumerable<Guid> SelectedServiceTypes { get; set; }
    }
}
