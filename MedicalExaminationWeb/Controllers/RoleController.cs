using System;
using System.Linq;
using MedicalExamination.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationWeb.Controllers
{
    [Route("api/[controller]")]
    public sealed class RoleController : ControllerBase
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleController(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public ActionResult GetRoles()
        {
            return Ok(_roleManager.Roles);
        }

        [HttpGet]
        [Route("getrole")]
        public ActionResult GetRole(Guid roleId)
        {
            return Ok(_roleManager.Roles.Where(r => r.Id == roleId));
        }
    }
}
