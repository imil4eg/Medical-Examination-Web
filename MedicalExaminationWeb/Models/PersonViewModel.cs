using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public sealed class PersonViewModel
    {
        public PersonViewModel()
        {
            this.BirthDate = DateTime.Today;
            this.PassportIssueDate = DateTime.Today;
        }

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

        [DisplayName("ИНН")]
        [StringLength(12, ErrorMessage = "Длина данного поля должна быть 12 символов", MinimumLength = 12)]
        public string INN { get; set; }

        [DisplayName("СНИЛС")]
        [StringLength(10, ErrorMessage = "Длина данного поля должна быть 12 символов", MinimumLength = 10)]
        public string SNILS { get; set; }

        [DisplayName("Место выдачи паспорта")]
        public SelectList PassportIssuePlaces { get; set; }
        public Guid SelectedPassportIssuePlaceId { get; set; }
    }
}
