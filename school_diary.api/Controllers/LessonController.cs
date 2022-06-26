using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private lessonService homeService;

        public LessonController(lessonService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLessons()
        {
            var listOfLessons = await homeService.GetAllLessons();

            return Ok(listOfLessons);
        }

        [HttpPost]
        [Route("{uuid}")]
        public async Task<IActionResult> GetUserLessons([FromBody] Guid uuid)
        {
            var listOfLessons = await homeService.GetUserLessons(uuid.ToString());

            // TODO - Add viewmodel to return

            return Ok(listOfLessons);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> CreateLesson(Lesson lesson)
        {
            await homeService.AddLesson(lesson);

            return Ok();
        }

        [HttpPut]
        [Route("change/{id:int}")]
        public async Task<IActionResult> PutLesson(int id, string lesson)
        {
            await homeService.PutLesson(id, lesson);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            await homeService.DeleteLesson(id);

            return Ok();
        }
    }
}
