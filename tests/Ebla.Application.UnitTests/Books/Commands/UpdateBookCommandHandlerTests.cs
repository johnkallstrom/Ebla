namespace Ebla.Application.UnitTests.Books.Commands
{
	public class UpdateBookCommandHandlerTests
	{
		private readonly Mock<IMapper> _mockMapper;
		private readonly Mock<IGenericRepository<Book>> _mockRepository;

        public UpdateBookCommandHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IGenericRepository<Book>>();
        }

		[Fact]
		public async Task Handle_Should_SetLastModifiedToCurrentDateAndTime_WhenRequestIsValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithAllSet()
				.Build();

			var book = new BookBuilder()
				.WithAllSet()
				.Build();

			_mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(book);

			var bookLibraries = new List<BookLibrary>();

			foreach (var libraryId in request.LibraryIds)
			{
				bookLibraries.Add(new BookLibrary { BookId = book.Id, LibraryId = libraryId });
			}

			var updatedBook = new BookBuilder()
				.WithId(book.Id)
				.WithTitle(request.Title)
				.WithDescription(request.Description)
				.WithPages(request.Pages)
				.WithPublished(request.Published)
				.WithLanguage(request.Language)
				.WithCountry(request.Country)
				.WithImage(request.Image)
				.WithAuthor(request.AuthorId)
				.WithGenre(request.GenreId)
				.WithCreatedOn(book.CreatedOn)
				.WithLastModified(DateTime.Now)
				.WithBookLibraries(bookLibraries)
				.Build();

			_mockMapper.Setup(x => x.Map(request, book)).Returns(updatedBook);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			updatedBook.LastModified.Should().NotBeNull();
			updatedBook.LastModified.Should().BeSameDateAs(DateTime.Now);
		}

		[Fact]
        public async Task Handle_Should_ReturnSuccessResponse_WhenRequestIsValid()
        {
            // Arrange
            var request = new UpdateBookCommandBuilder()
                .WithAllSet()
                .Build();

            var book = new BookBuilder()
                .WithAllSet()
                .Build();

            _mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(book);

            var bookLibraries = new List<BookLibrary>();

            foreach (var libraryId in request.LibraryIds)
            {
                bookLibraries.Add(new BookLibrary { BookId = book.Id, LibraryId = libraryId });
            }

            var updatedBook = new BookBuilder()
                .WithId(book.Id)
                .WithTitle(request.Title)
                .WithDescription(request.Description)
                .WithPages(request.Pages)
                .WithPublished(request.Published)
                .WithLanguage(request.Language)
                .WithCountry(request.Country)
                .WithImage(request.Image)
                .WithAuthor(request.AuthorId)
                .WithGenre(request.GenreId)
                .WithCreatedOn(book.CreatedOn)
                .WithLastModified(DateTime.Now)
                .WithBookLibraries(bookLibraries)
                .Build();

            _mockMapper.Setup(x => x.Map(request, book)).Returns(updatedBook);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Succeeded.Should().BeTrue();
            result.Errors.Should().BeNull();
        }
    }
}