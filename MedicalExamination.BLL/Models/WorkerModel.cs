using System;
using System.Collections.Generic;

namespace MedicalExamination.BLL
{
    public sealed class WorkerModel
    { 
        public PersonModel Person { get; set; }

        public int PersonId { get; set; }

        public IEnumerable<ProvideServiceModel> ProvideServices { get; set; }

        public IEnumerable<ServiceTypeModel> ServiceTypes { get; set; }

        public IEnumerable<PositionModel> Positions { get; set; }

        public IEnumerable<PositionTypeModel> PositionTypes { get; set; }

        public Guid Position { get; set; }
    }
}
