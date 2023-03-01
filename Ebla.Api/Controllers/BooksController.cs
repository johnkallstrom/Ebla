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
        [HttpGet]
        public async Task<IEnumerable<BookDto>> GetAll()
        {
            var books = await _mediator.Send(new GetBooksQuery());

            return books;
        }

        /// <summary>
        /// Get single book by id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpGet("{bookId}")]
        public async Task<BookDto> GetById(int bookId)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = bookId });

            return book;
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<Unit> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<Unit> Update([FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Delete an existing book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<Unit> Delete([FromBody] DeleteBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
