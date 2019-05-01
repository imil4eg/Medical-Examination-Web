using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExamination.Entities
{
    public sealed class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string INN { get; set; }

        public string SNILS { get; set; }

        public string PassportNumber { get; set; }

        public string PassportSeries { get; set; }

        public DateTime PassportIssueDate { get; set; }

        public Guid PassportIssuePlaceId { get; set; }
        [ForeignKey("PassportIssuePlaceId")]
        public PassportIssuePlaceType PassportIssuePlace { get; set; }
    }
}
