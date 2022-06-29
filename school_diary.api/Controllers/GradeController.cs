using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GradeController : ControllerBase
    {
        private gradeService gradeService;

        public GradeController(gradeService gradeService)
        {
            this.gradeService = gradeService;
        }

        /// <summary>
        /// Zwraca informacje o wszystkich ocenach z dziennika
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await gradeService.GetAllGrades();

            return Ok(grades);
        }

        /// <summary>
        /// Zwraca informacje o wszystkich ocenach w danej klasie przez ClassId
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Tutor,LocalAdmin,Admin")]
        [Route("{ClassId:int}")]
        public async Task<IActionResult> GetClassGrades(int ClassId)
        {
            var grades = await gradeService.GetClassGrades(ClassId);

            return Ok(grades);
        }

        /// <summary>
        /// Zwraca informacje o wszystkich ocenach z danego przedmiotu przez LessonId w danej klasie przez ClassId
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Tutor,LocalAdmin,Admin")]
        [Route("{LessonId:int}/{ClassId:int}")]
        public async Task<IActionResult> GetLessonClassGrades(int LessonId, int ClassId)
        {
            var grades = await gradeService.GetLessonClassGrades(ClassId, LessonId);

            return Ok(grades);
        }

        /// <summary>
        /// Zwraca informacje o wszystkich ocenach danego ucznia przez uuid
        /// </summary>
        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student,Teacher,Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetUserGrades(Guid uuid)
        {
            var userGrades = await gradeService.GetUserGrades(uuid.ToString());

            return Ok(userGrades);
        }

        /// <summary>
        /// Dodaje ocene do dziennika
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Teacher,Tutor,Admin,LocalAdmin")]
        public async Task<IActionResult> AddGrade(Grade grade)
        {
            await gradeService.AddGrade(grade);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje ocene w dzienniku
        /// </summary>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Teacher,Tutor,Admin,LocalAdmin")]
        public async Task<IActionResult> PutGrade(int id, Grade grade)
        {
            await gradeService.PutGrade(id, grade);

            return Ok();
        }

        /// <summary>
        /// Usuwa ocene z dziennika
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Teacher,Tutor,Admin,LocalAdmin")]
        public async Task<IActionResult> DeleteGrade(int id)
        {
            await gradeService.DeleteGrade(id);

            return Ok();
        }
    }
}
