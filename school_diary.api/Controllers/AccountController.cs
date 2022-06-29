using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using school_diary.api.Model;
using school_diary.api.Service;

namespace school_diary.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private accountService accountService;

        public AccountController(accountService accountService)
        {
            this.accountService = accountService;
        }

        /// <summary>
        /// Zwraca dane wszystkich użytkowników
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await accountService.GetAllUsers();

            return Ok(user);
        }

        /// <summary>
        /// Po zalogowaniu zwraca token autoryzacyjny
        /// </summary>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] Login user)
        {
            var token = await accountService.Login(user);

            return Ok(token);
        }

        /// <summary>
        /// Dodaje użytkownika do bazy danych
        /// </summary>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            await accountService.Register(user);

            return Ok();
        }
    }
}
