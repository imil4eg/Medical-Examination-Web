using System;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class PositionModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "worker_id")]
        public int WorkerId { get; set; }

        [DataMember(Name = "position_id")]
        public Guid PositionId { get; set; }
    }
}
