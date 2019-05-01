using System.Runtime.Serialization;

namespace MedicalExamination.BLL
{
    [DataContract]
    public sealed class TestModel
    {
        [DataMember(Name = "person")]
        public PersonModel Person { get; set; }

        [DataMember(Name = "patient")]
        public TestPatientModel Patient { get; set; }
    }
}
