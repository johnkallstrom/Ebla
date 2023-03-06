namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("token")]
        public async Task<string> GenerateToken(string username, string password)
        {
            var token = await _mediator.Send(new GenerateTokenCommand { Username = username, Password = password });

            return token;
        }
    }
}
