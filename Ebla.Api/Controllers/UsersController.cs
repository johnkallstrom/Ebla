namespace Ebla.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Login a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResult> Login(string username, string password)
        {
            var result = await _mediator.Send(new LoginUserCommand { Username = username, Password = password });

            return result;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            return users;
        }

        /// <summary>
        /// Get single user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<UserDto> GetById(Guid userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = userId });

            return user;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<Result<Guid>> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
