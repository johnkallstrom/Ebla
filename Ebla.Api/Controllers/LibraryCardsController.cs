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
        [HasReadAccess]
        [HttpGet("{userId}")]
        public async Task<LibraryCardResponse> GetByUserId(Guid userId)
        {
            var libraryCard = await _mediator.Send(new GetLibraryCardByUserIdQuery { UserId = userId });

            return libraryCard;
        }

        /// <summary>
        /// Create a new library card
        /// </summary>
        /// <param name="command"></param>a
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPost("create")]
        public async Task<Response<int>> Create([FromBody] CreateLibraryCardCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Update a library card
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPut("update")]
        public async Task<Response> Update([FromBody] UpdateLibraryCardCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Delete a library card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpDelete("delete/{id}")]
        public async Task<Response> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLibraryCardCommand { Id = id });

            return response;
        }
    }
}
