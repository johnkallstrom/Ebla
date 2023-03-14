namespace Ebla.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticationController(IMediator mediator, IJwtProvider jwtProvider)
        {
            _mediator = mediator;
            _jwtProvider = jwtProvider;
        }

        /// <summary>
        /// Generate a jwt token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("token")]
        public async Task<Result<string>> GenerateToken(string username, string password)
        {
            var result = await _mediator.Send(new GenerateTokenCommand { Username = username, Password = password });

            return result;
        }

        /// <summary>
        /// Validate a jwt token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpPost("validate")]
        public async Task<bool> ValidateToken(string token)
        {
            var result = await _jwtProvider.ValidateToken(token);
            return result;
        }
    }
}
