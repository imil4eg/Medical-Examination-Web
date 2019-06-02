using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public sealed class WorkerViewModel
    {
        public PersonViewModel Person { get; set; }

        public int PersonId { get; set; }

        public string FullName { get; set; }

        public IEnumerable<PositionViewModel> Positions { get; set; }

        public IEnumerable<ProvideServiceViewModel> ProvideServices { get; set; }

        public IEnumerable<PositionTypeViewModel> PositionTypes { get; set; }

        [DisplayName("Позиция")]
        public SelectList PositionsList { get; set; }
        public Guid SelectedPosition { get; set; }
    }
}
