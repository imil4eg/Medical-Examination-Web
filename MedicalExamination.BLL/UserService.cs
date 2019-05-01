using System;
using System.Collections.Generic;
using MedicalExamination.DAL;
using MedicalExamination.Entities;

namespace MedicalExamination.BLL
{
    public sealed class UserService : IUserService
    {
        private readonly IGenericRepository<ApplicationUser> _userRepository;

        public UserService(IGenericRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public ApplicationUser GetUserById(Guid id)
        {
            return _userRepository.GetById(id);
        }

        public void CreateUser(UserModel userModel)
        {
            

            //_userRepository.Insert(user);
        }

        public void UpdateUser(UserModel userModel)
        {
            //_userRepository.Update(user);
        }

        public void DeleteUser(UserModel userModel)
        {
            //_userRepository.Delete(user);
        }
    }
}
