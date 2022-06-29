using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoleController : ControllerBase
    {
        private roleService roleService;

        public RoleController(roleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleService.GetAllRoles();

            return Ok(roles);
        }

        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student,Teacher,Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetUserRole(Guid uuid)
        {
            var userRole = await roleService.GetUserRole(uuid.ToString());

            return Ok(userRole);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(Role role)
        {
            await roleService.AddRole(role);

            return Ok();
        }

        [HttpPut]
        [Route("change/{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            await roleService.PutRole(id, role);

            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleService.DeleteRole(id);

            return Ok();
        }
    }
}
