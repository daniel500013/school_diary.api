using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarkController : ControllerBase
    {
        private markService markService;

        public MarkController(markService markService)
        {
            this.markService = markService;
        }

        /// <summary>
        /// Zwraca informacje o wszystkich obecnościach uczniów
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "LocalAdmin,Admin")]
        public async Task<IActionResult> GetAllMarks()
        {
            var marks = await markService.GetAllMarks();

            return Ok(marks);
        }

        /// <summary>
        /// Zwraca informacje o wszystkich obecnościach ucznia przez uuid
        /// </summary>
        [HttpPost]
        [Route("{uuid:guid}")]
        [Authorize(Roles = "Tutor")]
        public async Task<IActionResult> GetUserMarks(Guid uuid)
        {
            await markService.GetUserMarks(uuid.ToString());

            return Ok();
        }

        /// <summary>
        /// Dodaje obecność do dziennika
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Mark
        ///     {
        ///        "present": false, - obecność ucznia
        ///        "date": "2020-03-29T23:09:07.721Z", - Data obecności ucznia
        ///        "FK_lessonId": 1 - Id lekcji na której uczeń był obecny
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Authorize(Roles = "Teacher,Tutor")]
        public async Task<IActionResult> AddMark(Marks mark)
        {
            await markService.AddMark(mark);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje obecność o wskazanym id w dzienniku
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Mark/{id}
        ///     {
        ///        "id": 1, - id obecności do aktualizacji
        ///        "present": false - obecność ucznia
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Teacher,Tutor")]
        public async Task<IActionResult> PutMark(int id, bool present)
        {
            await markService.PutMark(id, present);

            return Ok();
        }

        /// <summary>
        /// Usuwa obecność o wskazanym id z dzienniku
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            await markService.DeleteMark(id);

            return Ok();
        }
    }
}
