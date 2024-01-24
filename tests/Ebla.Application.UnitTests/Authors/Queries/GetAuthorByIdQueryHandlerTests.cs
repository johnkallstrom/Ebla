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
            var entity = new Author();
            entity = null;

            _mockRepository
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(entity);

            var request = new GetAuthorByIdQuery { Id = 0 };
            var handler = new GetAuthorByIdQueryHandler(_mockMapper.Object, _mockRepository.Object);

            var result = await handler
                .Invoking(x => x.Handle(request, default))
                .Should()
                .ThrowAsync<NotFoundException>();
        }

        [Fact]
        public async Task Handle_Should_ReturnAuthorDto_WhenAuthorExists()
        {
            // Arrange
            var entity = new Author();
            entity.Id = 2;
            entity.Name = "Ursula K. Le Guin";
            entity.Description = "Ursula Kroeber Le Guin (née Kroeber; /ˈkroʊbər lə ˈɡwɪn/ KROH-bər lə GWIN;[1] October 21, 1929 – January 22, 2018) was an American author best known for her works of speculative fiction, including science fiction works set in her Hainish universe, and the Earthsea fantasy series.";
            entity.Born = new DateTime(1929, 11, 21);
            entity.Country = "United States";
            entity.Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Ursula_Le_Guin_%283551195631%29_%28cropped%29.jpg/1280px-Ursula_Le_Guin_%283551195631%29_%28cropped%29.jpg";
            entity.CreatedOn = DateTime.Now;
            entity.LastModified = null;
            entity.Books = null;

            var dto = new AuthorDto(
                2,
                "Ursula K. Le Guin",
                "Ursula Kroeber Le Guin (née Kroeber; /ˈkroʊbər lə ˈɡwɪn/ KROH-bər lə GWIN;[1] October 21, 1929 – January 22, 2018) was an American author best known for her works of speculative fiction, including science fiction works set in her Hainish universe, and the Earthsea fantasy series.",
                new DateTime(1929, 11, 21),
                "United States",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/2/25/Ursula_Le_Guin_%283551195631%29_%28cropped%29.jpg/1280px-Ursula_Le_Guin_%283551195631%29_%28cropped%29.jpg",
                DateTime.Now,
                null);

            _mockRepository
                .Setup(x => x.Get(It.IsAny<int>()))
                .ReturnsAsync(entity);

            _mockMapper.Setup(x => x.Map<AuthorDto>(entity)).Returns(dto);

            var request = new GetAuthorByIdQuery { Id = 0 };
            var handler = new GetAuthorByIdQueryHandler(_mockMapper.Object, _mockRepository.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<AuthorDto>();
        }
    }
}