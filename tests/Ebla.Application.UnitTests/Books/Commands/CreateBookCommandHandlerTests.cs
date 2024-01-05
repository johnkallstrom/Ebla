namespace Ebla.Application.UnitTests.Books.Commands
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IGenericRepository<Book>> _mockRepository;

        public CreateBookCommandHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IGenericRepository<Book>>();
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccessResponse_WhenRequestIsValid()
        {
            // Arrange
            var request = ArrangeCreateBookCommandRequest();
            var entity = ArrangeBookEntity();

            _mockMapper.Setup(x => x.Map<Book>(request)).Returns(entity);

            var handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var response = await handler.Handle(request, default);

            // Assert
            response.Succeeded.Should().BeTrue();
            response.Errors.Should().BeNull();
        }

        [Fact]
        public async Task Handle_Should_InvokeAddAsyncAndSaveAsync_WhenRequestIsValid()
        {
            // Arrange
            var request = ArrangeCreateBookCommandRequest();
            var entity = ArrangeBookEntity();

            _mockMapper.Setup(x => x.Map<Book>(request)).Returns(entity);

            var handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var response = await handler.Handle(request, default);

            // Assert
            _mockRepository.Verify(x => x.AddAsync(entity), Times.Once);
            _mockRepository.Verify(x => x.SaveAsync(), Times.Exactly(2));
        }

        [Fact]
        public async Task Handle_Should_InvokeMap_WhenRequestIsValid()
        {
            // Arrange
            var request = ArrangeCreateBookCommandRequest();
            var entity = ArrangeBookEntity();

            _mockMapper.Setup(x => x.Map<Book>(request)).Returns(entity);

            var handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var response = await handler.Handle(request, default);

            // Assert
            _mockMapper.Verify(x => x.Map<Book>(request), Times.Once);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailureResponse_WhenRequestIsNotValid()
        {
            // Arrange
            var request = new CreateBookCommand();
            request.Title = null;
            request.Description = null;

            var handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var response = await handler.Handle(request, default);

            // Assert
            response.Succeeded.Should().BeFalse();
            response.Errors.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task Handle_Should_NeverInvokeAddAsyncOrSaveAsync_WhenRequestIsNotValid()
        {
            // Arrange
            var request = new CreateBookCommand();
            request.Title = null;
            request.Description = null;

            var handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var response = await handler.Handle(request, default);

            // Assert
            _mockRepository.Verify(x => x.AddAsync(default), Times.Never);
            _mockRepository.Verify(x => x.SaveAsync(), Times.Never);
        }

        [Fact]
        public async Task Handle_Should_ReturnOneOrMoreErrors_WhenRequestIsNotValid()
        {
            // Arrange
            var request = new CreateBookCommand();
            request.Title = null;
            request.Description = null;

            var handler = new CreateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var response = await handler.Handle(request, default);

            // Assert
            response.Errors.Should().BeOfType<string[]>();
            response.Errors.Should().HaveCountGreaterThanOrEqualTo(1);
            response.Errors.Should().Contain("Please enter a valid Title");
            response.Errors.Should().Contain("Please enter a valid Language");
        }

        #region Helpers
        private Book ArrangeBookEntity()
        {
            return new Book
            {
                Title = "Sample Title One",
                Description = "Lorem ipsum",
                Pages = 300,
                Published = DateTime.Now,
                Language = "Sample Language",
                Country = "Sample Country",
                Image = string.Empty,
                AuthorId = 1,
                GenreId = 1,
            };
        }

        private CreateBookCommand ArrangeCreateBookCommandRequest()
        {
            return new CreateBookCommand
            {
                Title = "Sample Title One",
                Description = "Lorem ipsum",
                Pages = 300,
                Published = DateTime.Now,
                Language = "Sample Language",
                Country = "Sample Country",
                Image = string.Empty,
                AuthorId = 1,
                GenreId = 1,
                LibraryIds = new int[]
                {
                    1,
                    2,
                    3,
                    4,
                    5
                }
            };
        }
        #endregion
    }
}