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
        /// Get single library card by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<LibraryCardDto> GetByUserId(Guid userId)
        {
            var libraryCard = await _mediator.Send(new GetLibraryCardByUserIdQuery { UserId = userId });

            return libraryCard;
        }

        /// <summary>
        /// Create a new library card
        /// </summary>
        /// <param name="command"></param>a
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IResult> Create([FromBody] CreateLibraryCardCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Update a library card
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IResult> Update([FromBody] UpdateLibraryCardCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Delete a library card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteLibraryCardCommand { Id = id });

            return result;
        }
    }
}
