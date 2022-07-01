using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ApproveController : ControllerBase
    {
        private approveService approveService;

        public ApproveController(approveService approveService)
        {
            this.approveService = approveService;
        }

        /// <summary>
        /// Zwraca pochwały wszystkich użytkowników
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Tutor,LocalAdmin,Admin")]
        public async Task<IActionResult> GetAllApproves()
        {
            var approves = await approveService.GetAllApproves();

            return Ok(approves);
        }

        /// <summary>
        /// Zwraca pochwały użytkownika przez uuid
        /// </summary>
        [HttpPost]
        [Route("{uuid:Guid}")]
        [Authorize(Roles = "Student,Teacher,LocalAdmin,Admin")]
        public async Task<IActionResult> GetUserApproves(Guid uuid)
        {
            var approves = await approveService.GetUserApproves(uuid.ToString());

            return Ok(approves);
        }

        /// <summary>
        /// Dodaje pochwałe do dziennika
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Approve
        ///     {
        ///        "positive": true,
        ///        "description": "Testowa pozytywna pochwała dla ucznia przypisanego do lekcji o id równym 1",
        ///        "FK_lessonId": 1
        ///     }
        ///
        /// </remarks>
        [HttpPost]
        [Authorize(Roles = "Teacher,LocalAdmin,Admin")]
        public async Task<IActionResult> AddApprove(Approve approve)
        {
            await approveService.AddApprove(approve);

            return Ok();
        }

        /// <summary>
        /// Aktualizuje pochwałe o wskazanym id w dzienniku
        /// </summary>
        /// <remarks>
        /// Przykładowe zapytanie:
        ///
        ///     POST /Approve/{id}
        ///     {
        ///        "positive": true,
        ///        "description": "Testowa pozytywna pochwała dla ucznia przypisanego do lekcji o id równym 1",
        ///        "FK_lessonId": 1
        ///     }
        ///
        /// </remarks>
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "Teacher,LocalAdmin,Admin")]
        public async Task<IActionResult> PutApprove(int id, Approve approve)
        {
            await approveService.PutApprove(id, approve);

            return Ok();
        }

        /// <summary>
        /// Usuwa pochwałe o wskazanym id z dziennika
        /// </summary>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "Teacher,LocalAdmin,Admin")]
        public async Task<IActionResult> DeleteApprove(int id)
        {
            await approveService.DeleteApprove(id);

            return Ok();
        }
    }
}
