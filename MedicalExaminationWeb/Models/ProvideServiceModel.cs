using System;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class ProvideServiceViewModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "position_id")]
        public Guid PositionId { get; set; }

        [DataMember(Name = "service_id")]
        public Guid ServiceId { get; set; }

        public ServiceViewModel Service { get; set; }
    }
}
