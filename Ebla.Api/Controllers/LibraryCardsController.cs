namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryCardsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LibraryCardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<Unit> Create([FromBody] CreateLibraryCardCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
