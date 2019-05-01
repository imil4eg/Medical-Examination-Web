using System.Collections.Generic;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    /// <summary>
    /// Interface for <see cref="ApplicationRole"/> entity service implementation
    /// </summary>
    public interface IRoleService
    {
        IEnumerable<ApplicationRole> GetAllRoles();
        ApplicationRole GetRoleById(int id);
        void CreateRole(ApplicationRole role);
        void UpdateRole(ApplicationRole role);
        void DeleteRole(ApplicationRole role);
    }
}
