namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public UsersController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("Authenticate")]
        public async Task<bool> Authenticate(string username, string password)
        {
            bool succeeded = await _identityService.AuthenticateAsync(username, password);

            return succeeded;
        }

        [HttpGet("Logout")]
        public async Task Logout()
        {
            await _identityService.LogoutAsync();
        }
    }
}
