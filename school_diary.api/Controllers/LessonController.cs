using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("{uuid}")]
        public async Task<IActionResult> GetUserLessons([FromBody] Guid uuid)
        {
            var listOfLessons = await homeService.GetUserLessons(uuid.ToString());

            return Ok(listOfLessons);
        }
    }
}
