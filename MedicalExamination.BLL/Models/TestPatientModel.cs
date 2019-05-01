using System;

namespace MedicalExamination.BLL
{
    public sealed class TestPatientModel
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public byte Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string PassportNumber { get; set; }

        public string PassportSeries { get; set; }

        public DateTime PassportIssueDate { get; set; }

        public Guid PassportIssuePlaceId { get; set; }
    }
}
