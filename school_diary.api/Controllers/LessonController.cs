using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;
using school_diary.api.Service.Interfaces;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private ILessonService homeService;

        public LessonController(ILessonService homeService)
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
        /// Zwraca informacje o wszystkich lekcjach użytkownika przez uuid
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
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Lesson
        ///     {
        ///        "name": "Matematyka", - Nazwa lekcji którą chcemy utworzyć
        ///        "FK_userId": "3fa85f64-5717-4562-b3fc-2c963f66afa6" - uuid użytkownika do którego chcemy przypisać lekcje
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> CreateLesson(Lesson lesson)
        {
            await homeService.AddLesson(lesson);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje nazwe lekcji o wskazanym id w dzienniku
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Lesson/{id}
        ///     {
        ///        "id": 1, - id lekcji którą chcemy zaktualizować
        ///        "lesson": "Polski" - nowa nazwa lekcji
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> PutLesson(int id, string lesson)
        {
            await homeService.PutLesson(id, lesson);

            return Ok();
        }

        /// <summary>
        /// Usuwa lekcje o wskazanym id z dziennika
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
