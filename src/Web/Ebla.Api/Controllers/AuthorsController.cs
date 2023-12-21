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
        /// Get authors
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet]
        public async Task<PagedResponse<AuthorSlimDto>> Get(int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetAuthorsQuery 
            { 
                PageNumber = pageNumber, 
                PageSize = pageSize 
            });

            return response;
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
