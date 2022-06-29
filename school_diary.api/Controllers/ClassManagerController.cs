using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClassManagerController : ControllerBase
    {
        private classManagerService classManagerService;

        public ClassManagerController(classManagerService classManagerService)
        {
            this.classManagerService = classManagerService;
        }

        /// <summary>
        /// Zwraca informacje o wszystkich klasach w dzienniku
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> GetAllClasses()
        {
            var allClasses = await classManagerService.GetAllClasses();

            return Ok(allClasses);
        }

        /// <summary>
        /// Zwraca informacje o klasie użytkownika przez jego uuid
        /// </summary>
        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student,Teacher,LocalAdmin,Admin")]
        public async Task<IActionResult> GetUserClass(Guid uuid)
        {
            var getUserClass = await classManagerService.GetUserClass(uuid.ToString());

            return Ok(getUserClass);
        }

        /// <summary>
        /// Dodaje klase do dzienniku
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddClass(UserClass userClass)
        {
            await classManagerService.AddClass(userClass);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje klase w dzienniku
        /// </summary>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> PutClass(int id, UserClass userClass)
        {
            await classManagerService.PutClass(id, userClass);

            return Ok();
        }

        /// <summary>
        /// Usuwa klase z dziennika
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            await classManagerService.DeleteUserClass(id);

            return Ok();
        }
    }
}
