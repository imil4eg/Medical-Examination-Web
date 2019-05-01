using System;
using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ApplicationUser"/> entity service implementation
    /// </summary>
    public interface IUserService
    {
        IEnumerable<ApplicationUser> GetAllUsers();
        ApplicationUser GetUserById(Guid id);
        void CreateUser(UserModel userModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(UserModel userModel);
    }
}
