namespace Ebla.Api.Controllers
{
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
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<CreateUserCommandResponse> Create(string username, string password)
        {
            var response = await _mediator.Send(new CreateUserCommand { Username = username, Password = password });

            return response;
        }
    }
}
