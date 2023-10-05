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
        [HttpGet]
        [HasReadAccess]
        public async Task<IEnumerable<LibraryDto>> GetAll()
        {
            var libraries = await _mediator.Send(new GetLibrariesQuery());

            return libraries;
        }
    }
}
