using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class RoleService : IRoleService
    {
        private readonly IGenericRepository<ApplicationRole> _roleRepository;

        public RoleService(IGenericRepository<ApplicationRole> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public IEnumerable<ApplicationRole> GetAllRoles()
        {
            return _roleRepository.GetAll();
        }

        public ApplicationRole GetRoleById(int id)
        {
            return _roleRepository.GetById(id);
        }

        public void CreateRole(ApplicationRole role)
        {
            _roleRepository.Insert(role);
        }

        public void UpdateRole(ApplicationRole role)
        {
            _roleRepository.Update(role);
        }

        public void DeleteRole(ApplicationRole role)
        {
            _roleRepository.Delete(role);
        }
    }
}
