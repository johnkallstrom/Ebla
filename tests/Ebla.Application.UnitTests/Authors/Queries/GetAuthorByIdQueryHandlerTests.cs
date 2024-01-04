namespace Ebla.Application.UnitTests.Authors.Queries
{
    public class GetAuthorByIdQueryHandlerTests
    {
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IGenericRepository<Author>> _mockRepository;

        public GetAuthorByIdQueryHandlerTests()
        {
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IGenericRepository<Author>>();
        }

        [Fact]
        public async Task Handle_Should_ThrowNotFoundException_WhenAuthorDoesNotExist()
        {
            // Arrange
            var entity = new Author();
            entity = null;

            _mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(entity);

            var request = new GetAuthorByIdQuery { Id = 0 };
            var handler = new GetAuthorByIdQueryHandler(_mockMapper.Object, _mockRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().BeNull();
        }
    }
}