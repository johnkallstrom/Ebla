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
        /// Get all libraries
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet]
        public async Task<IEnumerable<LibrarySlimResponse>> GetAll()
        {
            var libraries = await _mediator.Send(new GetLibrariesQuery());

            return libraries;
        }

        /// <summary>
        /// Get single library by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{id}")]
        public async Task<LibraryResponse> GetById(int id)
        {
            var library = await _mediator.Send(new GetLibraryByIdQuery { Id = id });

            return library;
        }
    }
}
