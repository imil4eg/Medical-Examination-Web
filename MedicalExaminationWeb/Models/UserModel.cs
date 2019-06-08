using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace MedicalExaminationWeb
{
    public sealed class UserModel
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
