using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ClassManagerController : ControllerBase
    {
        private classManagerService classManagerService;

        public ClassManagerController(classManagerService classManagerService)
        {
            this.classManagerService = classManagerService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetAllClasses()
        {
            var allClasses = await classManagerService.GetAllClasses();

            return Ok(allClasses);
        }

        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student,Teacher")]
        public async Task<IActionResult> GetUserClass(Guid uuid)
        {
            var getUserClass = await classManagerService.GetUserClass(uuid.ToString());

            return Ok(getUserClass);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddClass(UserClass userClass)
        {
            await classManagerService.AddClass(userClass);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutClass(int id, UserClass userClass)
        {
            await classManagerService.PutClass(id, userClass);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClass(int id)
        {
            await classManagerService.DeleteUserClass(id);

            return Ok();
        }
    }
}
