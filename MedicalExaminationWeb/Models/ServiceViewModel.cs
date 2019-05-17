using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    [DataContract]
    public sealed class ServiceViewModel
    {
        public Guid Id { get; set; }

        [DisplayName("Название усулги")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым")]
        public string Name { get; set; }

        [DisplayName("Код МКБ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым")]
        public string Code { get; set; }

        [DisplayName("Пол услуги")]
        public GenderOfService Gender { get; set; }

        [DisplayName("От")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым")]
        [MaxLength(2, ErrorMessage = "Число не может быть больше двух знаков")]
        [MinLength(2, ErrorMessage = "Число не может быть меньше двух знаков")]
        public string AgeFrom
        {
            get
            {
                if (string.IsNullOrEmpty(_ageFrom))
                    _ageFrom = this.AgeRange.Split('-')[0];

                return _ageFrom;
            }

            set => _ageFrom = value;
        }
        private string _ageFrom;

        [DisplayName("До")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Это поле не может быть пустым")]
        [MaxLength(2, ErrorMessage = "Число не может быть больше двух знаков")]
        [MinLength(2, ErrorMessage = "Число не может быть меньше двух знаков")]
        public string AgeTo
        {
            get
            {
                if (string.IsNullOrEmpty(_ageTo))
                    _ageTo = this.AgeRange.Split('-')[1];

                return _ageTo;
            }

            set => _ageTo = value;
        }

        private string _ageTo;

        [DisplayName("Возраст для прохождения")]
        public string AgeRange
        {
            get
            {
                if (!string.IsNullOrEmpty(_ageTo) && !string.IsNullOrEmpty(_ageFrom) && _ageRange.Equals(" - "))
                    _ageRange = $"{this.AgeFrom}-{this.AgeTo}";

                return _ageRange;
            }
            set => _ageRange = string.IsNullOrEmpty(value) ? " - " : value;
        }

        private string _ageRange = " - ";

        [DisplayName("Включить в диспансеризацию")]
        public bool IsIncluded { get; set; }
    }
}
