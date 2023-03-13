namespace Ebla.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Generate a jwt token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("token")]
        public async Task<IResult<string>> GenerateToken(string username, string password)
        {
            var result = await _mediator.Send(new GenerateTokenCommand { Username = username, Password = password });

            return result;
        }
    }
}
