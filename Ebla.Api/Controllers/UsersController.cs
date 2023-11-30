using Ebla.Application.Common.Results;

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
        /// Login a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<LoginResponse> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet]
        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            return users;
        }

        /// <summary>
        /// Get single user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{userId}")]
        public async Task<UserResponse> GetById(Guid userId)
        {
            var user = await _mediator.Send(new GetUserByIdQuery { Id = userId });

            return user;
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPost("create")]
        public async Task<Result<Guid>> Create([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPut("update")]
        public async Task<Result> Update([FromBody] UpdateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpDelete("delete/{id}")]
        public async Task<Result> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });

            return result;
        }
    }
}
