using Microsoft.AspNetCore.Authorization;

namespace Ebla.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        // Action Methods
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string username, string password)
        {
            var succeeded = await _identityService.LoginAsync(username, password);

            if (succeeded)
            {
                return RedirectToStart();
            }

            return View();
        }

        [HttpGet]
        [Authorize(Policy = "RequireAdministratorAndUserRole")]
        public async Task<IActionResult> Logout()
        {
            await _identityService.LogoutAsync();

            return RedirectToStart();
        }

        // Helper Methods
        private RedirectToActionResult RedirectToStart()
        {
            return RedirectToAction(nameof(StartController.Index), "Start");
        }
    }
}