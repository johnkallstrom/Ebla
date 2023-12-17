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
        public async Task<IEnumerable<AuthorSlimDto>> GetAll(int pageNumber, int pageSize)
        {
            var authors = await _mediator.Send(new GetAuthorsQuery 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize 
            });

            return authors;
        }

        /// <summary>
        /// Get single author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{id}")]
        public async Task<AuthorDto> GetById(int id)
        {
            var author = await _mediator.Send(new GetAuthorByIdQuery { Id = id });

            return author;
        }
    }
}
