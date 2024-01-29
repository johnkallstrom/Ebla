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
        public async Task<IEnumerable<BookSlimDto>> GetAll()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());

            return books;
        }

        /// <summary>
        /// Get single book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HasReadAccess]
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
        [HasWriteAccess]
        [HttpPost("create")]
        public async Task<Result<int>> Create([FromBody] CreateBookCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Update a book
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpPut("update")]
        public async Task<Result> Update([FromBody] UpdateBookCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }

        /// <summary>
        /// Delete books
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HasWriteAccess]
        [HttpDelete("delete")]
        public async Task<Result> Delete([FromBody] DeleteBooksCommand command)
        {
            var response = await _mediator.Send(command);

            return response;
        }
    }
}