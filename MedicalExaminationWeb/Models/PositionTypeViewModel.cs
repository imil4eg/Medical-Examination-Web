using System;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class PositionTypeViewModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
}
