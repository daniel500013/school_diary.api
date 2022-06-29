using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private lessonService homeService;

        public LessonController(lessonService homeService)
        {
            this.homeService = homeService;
        }

        /// <summary>
        /// Zwraca informacje o wszystkich lekcjach w dzienniku
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetAllLessons()
        {
            var listOfLessons = await homeService.GetAllLessons();

            return Ok(listOfLessons);
        }

        /// <summary>
        /// Zwraca informacje o wszystkich lekcjach użytkownika
        /// </summary>
        [HttpPost]
        [Route("{uuid}")]
        [Authorize(Roles = "Student,Teacher,Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetUserLessons([FromBody] Guid uuid)
        {
            var listOfLessons = await homeService.GetUserLessons(uuid.ToString());

            return Ok(listOfLessons);
        }

        /// <summary>
        /// Dodaje lekcje do dziennika
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> CreateLesson(Lesson lesson)
        {
            await homeService.AddLesson(lesson);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje lekcje w dzienniku
        /// </summary>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> PutLesson(int id, string lesson)
        {
            await homeService.PutLesson(id, lesson);

            return Ok();
        }

        /// <summary>
        /// Usuwa lekcje z dziennika
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await homeService.DeleteLesson(id);

            return Ok();
        }
    }
}
