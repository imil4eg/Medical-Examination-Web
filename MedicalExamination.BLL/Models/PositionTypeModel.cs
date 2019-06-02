using System;
using System.Collections.Generic;

namespace MedicalExamination.BLL
{
    public sealed class PositionTypeModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProvideServiceModel> ProvideServices { get; set; }

        public IEnumerable<ServiceTypeModel> ServiceTypes { get; set; }
    }
}
