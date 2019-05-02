using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public class PersonModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым.")]
        public string LastName { get; set; }

        [DisplayName("Имя")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым.")]
        public string FirstName { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Пол")]
        public Gender Gender { get; set; }

        [DisplayName("Дата рождения")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым.")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Номер паспорта")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым.")]
        public string PassportNumber { get; set; }

        [DisplayName("Серия паспорта")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым.")]
        public string PassportSeries { get; set; }

        [DisplayName("Дата выдачи паспорта")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым.")]
        public DateTime PassportIssueDate { get; set; }

        [DisplayName("Место выдачи")]
        public Guid PassportIssuePlaceId { get; set; }
    }
}
