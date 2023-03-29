namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all authors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Policy = Policies.ReadAccess)]
        public async Task<IEnumerable<AuthorDto>> GetAll()
        {
            var authors = await _mediator.Send(new GetAuthorsQuery());

            return authors;
        }
    }
}
