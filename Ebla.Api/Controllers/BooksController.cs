namespace Ebla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet]
        public async Task<IEnumerable<BookSlimResponse>> GetAll()
        {
            var books = await _mediator.Send(new GetBooksQuery());

            return books;
        }

        /// <summary>
        /// Get single book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasReadAccess]
        [HttpGet("{id}")]
        public async Task<BookResponse> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = id });

            return book;
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPost("create")]
        public async Task<Response<int>> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPut("update")]
        public async Task<Response> Update([FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpDelete("delete/{id}")]
        public async Task<Response> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand { Id = id });

            return result;
        }
    }
}