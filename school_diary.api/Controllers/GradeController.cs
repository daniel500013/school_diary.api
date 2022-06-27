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
    public class GradeController : ControllerBase
    {
        private gradeService gradeService;
            
        public GradeController(gradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        [HttpGet]
        [Authorize(Roles = "Teacher, LocalAdmin")]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await gradeService.GetAllGrades();

            return Ok(grades);
        }

        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetUserGrades(Guid uuid)
        {
            var userGrades = await gradeService.GetUserGrades(uuid.ToString());

            return Ok(userGrades);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddGrade(Grade grade)
        {
            await gradeService.AddGrade(grade);

            return Ok();
        }

        [HttpPut]
        [Route("change/{id:int}")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            await gradeService.PutGrade(id, grade);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            await gradeService.DeleteGrade(id);

            return Ok();
        }
    }
}
