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
        public async Task Handle_Should_ThrowNotFoundException_WhenBooksDoNotExist()
        {
            var entities = Enumerable.Empty<Book>();

            _mockBookRepository
                .Setup(x => x.GetBooksAsync(It.IsAny<int[]>()))
                .ReturnsAsync(entities);

            var request = new DeleteBooksCommand { Ids = [-1, 398, 7310] };
            var handler = new DeleteBooksCommandHandler(_mockMapper.Object, _mockBookRepository.Object);

            var result = await handler
                .Invoking(x => x.Handle(request, default))
                .Should()
                .ThrowAsync<NotFoundException>();
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

            var result = await handler
                .Invoking(x => x.Handle(request, default))
                .Should()
                .ThrowAsync<NotFoundException>();
        }
    }
}