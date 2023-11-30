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
        [HasReadAccess]
        [HttpGet]
        public async Task<IEnumerable<AuthorSlimResponse>> GetAll()
        {
            var authors = await _mediator.Send(new GetAuthorsQuery());

            return authors;
        }

        /// <summary>
        /// Get single author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{id}")]
        public async Task<AuthorResponse> GetById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery { Id = id });

            return author;
        }
    }
}
