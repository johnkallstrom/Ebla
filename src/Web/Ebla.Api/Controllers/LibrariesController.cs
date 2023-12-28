namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibrariesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get paged libraries
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet]
        public async Task<PagedResponse<LibrarySlimDto>> GetPaged(int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetPagedLibrariesQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return response;
        }

        /// <summary>
        /// Get single library by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{id}")]
        public async Task<LibraryDto> GetById(int id)
        {
            var library = await _mediator.Send(new GetLibraryByIdQuery { Id = id });

            return library;
        }
    }
}
