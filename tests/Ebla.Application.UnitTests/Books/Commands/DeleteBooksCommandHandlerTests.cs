namespace Ebla.Application.UnitTests.Books.Commands
{
    public class DeleteBooksCommandHandlerTests
    {
        private readonly Mock<IBookRepository> _mockBookRepository;
        private readonly Mock<IMapper> _mockMapper;

        public DeleteBooksCommandHandlerTests()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResultWithNoErrors_WhenRequestIsValidAndBooksExist()
        {
            // Arrange
            var books = GetBooks();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(books);

            var request = new DeleteBooksCommand { Ids = [1] };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Succeeded.Should().BeTrue();
            result.Errors.Should().BeNull();
        }

        [Fact]
        public async Task Handle_Should_ReturnOneErrorContainingExpectedErrorMessage_WhenRequestIsNotValid()
        {
            // Arrange
            var books = Enumerable.Empty<Book>();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(books);

            var request = new DeleteBooksCommand { Ids = null };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            string expectedErrorMsg = "Please enter a valid Ids";

            result.Succeeded.Should().BeFalse();
            result.Errors.Should().HaveCount(1);
            result.Errors.Should().Contain(expectedErrorMsg);
        }

        [Fact]
        public async Task Handle_Should_NeverInvokeDeleteBooks_WhenRequestIsNotValid()
        {
            // Arrange
            var books = Enumerable.Empty<Book>();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(books);

            var request = new DeleteBooksCommand { Ids = null };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            _mockBookRepository.Verify(x => x.DeleteBooks(books), Times.Never);
            result.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_NeverInvokeGetBooksAsync_WhenRequestIsNotValid()
        {
            // Arrange
            var books = Enumerable.Empty<Book>();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(books);

            var request = new DeleteBooksCommand { Ids = null };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            _mockBookRepository.Verify(x => x.GetBooksAsync(request.Ids), Times.Never);
            result.Succeeded.Should().BeFalse();
        }

        [Fact]
        public async Task Handle_Should_InvokeGetBooksAsyncOnce_WhenRequestIsValidAndBooksExist()
        {
            // Arrange
            var books = GetBooks();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(books);

            var request = new DeleteBooksCommand { Ids = [1] };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            _mockBookRepository.Verify(x => x.GetBooksAsync(request.Ids), Times.Once);
            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_InvokeDeleteBooksOnce_WhenRequestIsValidAndBooksExist()
        {
            // Arrange
            var books = GetBooks();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(books);

            var request = new DeleteBooksCommand { Ids = [1] };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            _mockBookRepository.Verify(x => x.DeleteBooks(books), Times.Once);
            result.Succeeded.Should().BeTrue();
        }

        [Fact]
        public async Task Handle_Should_ThrowNotFoundException_WhenBooksDoNotExist()
        {
            var entities = Enumerable.Empty<Book>();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(entities);

            var request = new DeleteBooksCommand { Ids = [-1, 398, 7310] };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            string expectedMsg = $"Entities 'booksToDelete' with identifiers '-1, 398, 7310' was not found";
            var result = await handler
                .Invoking(x => x.Handle(request, default))
                .Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage(expectedMsg);
        }

        [Fact]
        public async Task Handle_Should_ThrowNotFoundException_WhenBooksIsNull()
        {
            var entities = new List<Book>();
            entities = null;

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(entities);

            var request = new DeleteBooksCommand { Ids = [-1, 398, 7310] };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            string expectedMsg = $"Entities 'booksToDelete' with identifiers '-1, 398, 7310' was not found";
            var result = await handler
                .Invoking(x => x.Handle(request, default))
                .Should()
                .ThrowAsync<NotFoundException>()
                .WithMessage(expectedMsg);
        }

        #region Helpers
        private List<Book> GetBooks()
        {
            var entities = new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "Rendezvous with Rama",
                    Pages = 256,
                    Published = new DateTime(1973, 6, 1),
                    Language = "English",
                    Country = "United Kingdom",
                    Image = "https://upload.wikimedia.org/wikipedia/en/e/e1/Rama_copy.jpg",
                    AuthorId = 1,
                    GenreId = 1
                }
            };

            return entities;
        }
        #endregion
    }
}