using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MedicalExamination.BLL;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimpleMapper;

namespace MedicalExaminationWeb.Controllers
{
    public sealed class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWorkerService _workerService;
        private readonly IPositionTypeService _positionTypeService;
        private readonly IPassportIssuePlaceTypeService _passportIssuePlaceTypeService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            IWorkerService workerService,
            IPositionTypeService positionTypeService, IPassportIssuePlaceTypeService passportIssuePlaceTypeService)
        {
            _userManager = userManager;
            _workerService = workerService;
            _positionTypeService = positionTypeService;
            _passportIssuePlaceTypeService = passportIssuePlaceTypeService;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = _userManager.Users.AsEnumerable();

            var userModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                var worker = _workerService.GetWorker(user.WorkerId);
                var userViewModel = new UserViewModel
                {
                    User = new UserModel {Id = user.Id, UserName = user.UserName},
                    Worker = SimpleMapper.Mapper.Map<WorkerModel, WorkerViewModel>(worker)
                };

                userViewModel.Worker.Person = SimpleMapper.Mapper.Map<PersonModel, PersonViewModel>(worker.Person);

                var roles = await _userManager.GetRolesAsync(user);

                userViewModel.CurrentUserRole = new RoleViewModel {Name = roles.First()};

                userModels.Add(userViewModel);
            }

            return View("Users", userModels);
        }

        [HttpGet]
        [Route("getuser")]
        public ActionResult GetUser(Guid id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            var model = new UserViewModel
            {
                Worker = new WorkerViewModel
                {
                    Person = new PersonViewModel()
                }
            };

            this.FullFillArrays(model);
            
            return View("CreateUser", model);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                this.FullFillArrays(model);

                return View(model);
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasNumber.IsMatch(model.User.Password) ||
                !hasUpperChar.IsMatch(model.User.Password) ||
                !hasLowerChar.IsMatch(model.User.Password) ||
                !hasSymbols.IsMatch(model.User.Password))
            {
                ModelState.AddModelError("", "Пароль должен содержать: " +
                                             "Хотя бы одну букву малого регистра;\n" +
                                             "Хотя бы одну букву большого регистра;\n" +
                                             "Хотя бы одну цифру;\n" +
                                             "Хотя бы один спец. символ;");

                this.FullFillArrays(model);

                return View("CreateUser", model);
            }

            var worker = SimpleMapper.Mapper.Map<WorkerViewModel, MedicalExamination.BLL.WorkerModel>(model.Worker);
            worker.Person =
                SimpleMapper.Mapper.Map<PersonViewModel, MedicalExamination.BLL.PersonModel>(model.Worker.Person);
            worker.Position = model.Worker.SelectedPosition;
            worker.Person.PassportIssuePlaceId = model.Worker.Person.SelectedPassportIssuePlaceId;

            worker.PersonId = _workerService.CreateWorker(worker);

            var user = new ApplicationUser
            {
                UserName = model.User.UserName,
                WorkerId = worker.PersonId,
                Password = model.User.Password
            };

            var result = await _userManager.CreateAsync(user, user.Password);

            var role = await _roleManager.FindByIdAsync(model.SelectedRoleId.ToString());
            await _userManager.AddToRoleAsync(user, role.Name);

            return RedirectToAction("GetAllUsers", "User");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var userModel = new UserViewModel
            {
                User = new UserModel
                {
                    Id = userId,
                    UserName = user.UserName
                }
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            var roles = _roleManager.Roles.AsEnumerable();
            userModel.Roles = new SelectList(roles, "Id", "Name");
            userModel.SelectedRoleId = roles.FirstOrDefault(r => r.Name.Equals(userRoles.First())).Id;

            userModel.CurrentUserRole = new RoleViewModel {Id = userModel.SelectedRoleId};

            return View("UserProfile", userModel);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UserViewModel model)
        {
            if (model.CurrentUserRole.Id == model.SelectedRoleId)
                return RedirectToAction("GetAllUsers");

            var roles = _roleManager.Roles.AsEnumerable();

            var newRole = roles.FirstOrDefault(r => r.Id == model.SelectedRoleId);
            var oldRole = roles.FirstOrDefault(r => r.Id == model.CurrentUserRole.Id);

            var user = await _userManager.FindByIdAsync(model.User.Id.ToString());

            await _userManager.RemoveFromRoleAsync(user, oldRole.Name);
            await _userManager.AddToRoleAsync(user, newRole.Name);

            return RedirectToAction("GetAllUsers");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteUser(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            await _userManager.DeleteAsync(user);

            return RedirectToAction("GetAllUsers");
        }

        [NonAction]
        public string GetIdentityErrorsDescription(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(e => e.Description));
        }

        [NonAction]
        private void FullFillArrays(UserViewModel model)
        {
            var positions = _positionTypeService.GetAllPositionTypes();
            model.Worker.PositionsList = new SelectList(positions, "Id", "Name");
            model.Worker.SelectedPosition = positions.First().Id;

            var passportIssuePlaces = _passportIssuePlaceTypeService.GetAllPassportIssuePlaces();
            model.Worker.Person.PassportIssuePlaces = new SelectList(passportIssuePlaces, "Id", "Name");
            model.Worker.Person.SelectedPassportIssuePlaceId = passportIssuePlaces.First().Id;

            var roles = _roleManager.Roles.AsEnumerable();
            model.Roles = new SelectList(roles, "Id", "Name");
            model.SelectedRoleId = roles.First().Id;
        }
    }
}
