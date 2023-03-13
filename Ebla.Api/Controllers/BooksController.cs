namespace Ebla.Api.Controllers
{
    [Authorize]
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
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<BookDto> GetById(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery { Id = id });

            return book;
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<IResult<int>> Create([FromBody] CreateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IResult<int>> Update([FromBody] UpdateBookCommand command)
        {
            var result = await _mediator.Send(command);

            return result;
        }

        /// <summary>
        /// Delete a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete/{id}")]
        public async Task<IResult<int>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBookCommand { Id = id });

            return result;
        }
    }
}