using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class WorkerViewModel
    {
        [DataMember(Name = "person")]
        public PersonViewModel Person { get; set; }

        public int PersonId { get; set; }

        public string FullName { get; set; }

        public IEnumerable<PositionViewModel> Positions { get; set; }

        public IEnumerable<ProvideServiceViewModel> ProvideServices { get; set; }
    }
}
