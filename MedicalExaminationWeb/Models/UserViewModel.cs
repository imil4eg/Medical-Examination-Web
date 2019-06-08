using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalExaminationWeb
{
    public class UserViewModel
    {
        public UserModel User { get; set; }

        public WorkerViewModel Worker { get; set; }

        [DisplayName("Роль")]
        public SelectList Roles { get; set; }
        public Guid SelectedRoleId { get; set; }

        public RoleViewModel CurrentUserRole { get; set; }
    }
}
