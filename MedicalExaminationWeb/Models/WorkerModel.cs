using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class WorkerModel
    {
        [DataMember(Name = "person")]
        public PersonModel Person { get; set; }
    }
}
