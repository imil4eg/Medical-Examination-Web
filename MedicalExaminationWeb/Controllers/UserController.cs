using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalExamination.BLL;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            
            _userManager = userManager;
        }

        [HttpGet]
        public ActionResult GetAllUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        [HttpGet]
        [Route("getuser")]
        public ActionResult GetUser(Guid id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateUser([FromBody] UserModel model)
        {
            try
            {
                var user = SimpleMapper.Mapper.Map<UserModel, ApplicationUser>(model);
                var worker = new Worker
                {
                    PersonId = model.Worker.Person.Id
                };
                user.Worker = worker;
                var result = await _userManager.CreateAsync(user, user.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }

                throw new Exception(this.GetIdentityErrorsDescription(result.Errors));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> UpdateUser([FromBody] UserModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    return BadRequest("User doesn't exist");
                }

                if (!string.IsNullOrEmpty(model.OldPassword))
                {
                    var passwordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

                    if (!passwordResult.Succeeded)
                    {
                        throw new Exception(this.GetIdentityErrorsDescription(passwordResult.Errors));
                    }
                }
                //user.SecurityStamp = Guid.NewGuid().ToString();
                user.Password = model.Password;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok();
                }

                throw new Exception(this.GetIdentityErrorsDescription(result.Errors));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> DeleteUser([FromBody] UserModel model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user == null)
                    return BadRequest("User doesn't exist");

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Ok();
                }

                throw new Exception(this.GetIdentityErrorsDescription(result.Errors));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [NonAction]
        public string GetIdentityErrorsDescription(IEnumerable<IdentityError> errors)
        {
            return string.Join(", ", errors.Select(e => e.Description));
        }
    }
}
