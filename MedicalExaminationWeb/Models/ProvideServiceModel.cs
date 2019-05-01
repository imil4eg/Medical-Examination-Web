using System;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class ProvideServiceModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "position_id")]
        public Guid PositionId { get; set; }

        [DataMember(Name = "service_id")]
        public Guid ServiceId { get; set; }
    }
}
