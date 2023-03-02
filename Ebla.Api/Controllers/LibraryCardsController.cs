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

        /// <summary>
        /// Create a new library card
        /// </summary>
        /// <param name="command"></param>a
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<CreateLibraryCardResponse> Create([FromBody] CreateLibraryCardCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}
