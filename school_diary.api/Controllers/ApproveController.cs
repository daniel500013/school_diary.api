using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApproveController : ControllerBase
    {
        private approveService approveService;

        public ApproveController(approveService approveService)
        {
            this.approveService = approveService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApproves()
        {
            var approves = await approveService.GetAllApproves();

            return Ok(approves);
        }

        [HttpPost]
        [Route("{uuid:Guid}")]
        public async Task<IActionResult> GetUserApproves(Guid uuid)
        {
            var approves = await approveService.GetUserApproves(uuid.ToString());

            return Ok(approves);
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddApprove(Approve approve)
        {
            await approveService.AddApprove(approve);

            return Ok();
        }

        [HttpPut]
        [Route("change/{id:int}")]
        public async Task<IActionResult> PutApprove(int id, Approve approve)
        {
            await approveService.PutApprove(id, approve);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> DeleteApprove(int id)
        {
            await approveService.DeleteApprove(id);

            return Ok();
        }
    }
}
