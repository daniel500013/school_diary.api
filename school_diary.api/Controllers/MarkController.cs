using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkController : ControllerBase
    {
        private markService markService;

        public MarkController(markService markService)
        {
            this.markService = markService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarks()
        {
            var marks = await markService.GetAllMarks();

            return Ok(marks);
        }

        [HttpPost]
        [Route("{uuid:guid}")]
        public async Task<IActionResult> GetAllMarks(Guid uuid)
        {
            await markService.GetUserMarks(uuid.ToString());

            return Ok();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddMark(Marks mark)
        {
            await markService.AddMark(mark);

            return Ok();
        }

        [HttpPut]
        [Route("change/{id:int}")]
        public async Task<IActionResult> PutMark(int id, bool present)
        {
            await markService.PutMark(id, present);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            await markService.DeleteMark(id);

            return Ok();
        }
    }
}
