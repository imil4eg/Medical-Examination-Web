using System;
using System.Linq;
using System.Threading.Tasks;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class UserRoleController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public UserRoleController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserRoles(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var roles = await _userManager.GetRolesAsync(user);

            return Ok(roles);
        }

        [HttpPost]
        [Route("addrole")]
        public async Task<ActionResult> AddUserToRole(string userName, string roleName)
        {

            if (!_roleManager.Roles.Any(r => r.Name.Equals(roleName)))
            {
                return BadRequest("Role doesn't exist");
            }

            try
            {
                var user = await _userManager.FindByNameAsync(userName);

                if (user == null)
                {
                    throw new Exception("User doesn't exist.");
                }

                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Any(r => r.Equals(roleName)))
                {
                    throw new Exception("User already in that role.");
                }
               
                await _userManager.AddToRoleAsync(user, roleName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleterole")]
        public async Task<ActionResult> ExcludeFromRole(string userName, string roleName)
        {
            if (!_roleManager.Roles.Any(r => r.Name.Equals(roleName)))
            {
                return BadRequest("Role doesn't exist");
            }

            try
            {
                var user = await _userManager.FindByNameAsync(userName);

                if (user == null)
                {
                    throw new Exception("User doesn't exist.");
                }

                var roles = await _userManager.GetRolesAsync(user);

                if (!roles.Contains(roleName))
                {
                    throw new Exception("User not in that role.");
                }

                await _userManager.RemoveFromRoleAsync(user, roleName);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
