using Ebla.Application.LibraryCards.Commands.DeleteLibraryCard;

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
        public async Task<CreateLibraryCommandCardResponse> Create([FromBody] CreateLibraryCardCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Update a library card
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<UpdateLibraryCardCommandResponse> Update([FromBody] UpdateLibraryCardCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Delete a library card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<DeleteLibraryCardCommandResponse> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteLibraryCardCommand { Id = id });

            return response;
        }
    }
}
