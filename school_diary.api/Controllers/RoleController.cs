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

        /// <summary>
        /// Zwraca informacje o wszystkich rolach w dzienniku
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await roleService.GetAllRoles();

            return Ok(roles);
        }

        /// <summary>
        /// Zwraca informacje o roli użytkownika przez uuid
        /// </summary>
        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student,Teacher,Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetUserRole(Guid uuid)
        {
            var userRole = await roleService.GetUserRole(uuid.ToString());

            return Ok(userRole);
        }

        /// <summary>
        /// Dodaje role do dziennika
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Role
        ///     {
        ///        "name": "SuperAdmin" - nazwa nowej roli
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddRole(Role role)
        {
            await roleService.AddRole(role);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje role o wskazanym id w dzienniku
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Role/{id}
        ///     {
        ///        "id": 1, - id roli do aktualizacji
        ///        "name": "SuperAdmin" - nazwa nowej roli
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            await roleService.PutRole(id, role);

            return Ok();
        }

        /// <summary>
        /// Usuwa role o wskazanym id z dziennika
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await roleService.DeleteRole(id);

            return Ok();
        }
    }
}
