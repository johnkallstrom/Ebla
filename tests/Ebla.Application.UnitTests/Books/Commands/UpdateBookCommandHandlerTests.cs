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
		public async Task Handle_Should_ReturnFailureResultWithErrors_WhenRequestIsNotValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithId(-1)
				.WithTitle(string.Empty)
				.Build();

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			result.Succeeded.Should().BeFalse();
			result.Errors.Should().NotBeEmpty();
			result.Errors.Should().Contain("Please enter a valid Title");
		}

		[Fact]
		public async Task Handle_Should_ThrowNotFoundException_WhenRequestIsValidButBookDoesNotExist()
		{
			var request = new UpdateBookCommandBuilder()
				.WithId(-1)
				.WithTitle("Updated Title")
				.WithDescription("Lorem ipsum dolor")
				.WithPages(513)
				.WithPublished(new DateTime(1999, 1, 1))
				.WithLanguage("English")
				.WithCountry("United Kingdom")
				.WithImage("www.imageurl.net")
				.WithAuthor(1)
				.WithGenre(1)
				.WithLibraries([1, 2, 3])
				.Build();

			var bookToUpdate = new BookBuilder()
				.AsNull()
				.Build();

			_mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(bookToUpdate);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			var result = await handler
				.Invoking(x => x.Handle(request, default))
				.Should()
				.ThrowAsync<NotFoundException>()
				.WithMessage($"Entity '{nameof(bookToUpdate)}' with identifier '{request.Id}' was not found");
		}

		[Fact]
		public async Task Handle_Should_NeverInvokeSaveAsync_WhenRequestIsNotValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithId(-1)
				.WithDescription(string.Empty)
				.Build();

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			_mockRepository.Verify(x => x.SaveAsync(), Times.Never);
		}

		[Fact]
		public async Task Handle_Should_NeverInvokeUpdate_WhenRequestIsNotValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithId(-1)
				.WithDescription(string.Empty)
				.Build();

			var bookToUpdate = new BookBuilder()
				.AsNull()
				.Build();

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			_mockRepository.Verify(x => x.Update(bookToUpdate), Times.Never);
		}

		[Fact]
		public async Task Handle_Should_InvokeSaveAsyncOnce_WhenRequestIsValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithAllSet()
				.Build();

			var bookToUpdate = new BookBuilder()
				.WithAllSet()
				.Build();

			_mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(bookToUpdate);

			var bookLibraries = new List<BookLibrary>();

			foreach (var libraryId in request.LibraryIds)
			{
				bookLibraries.Add(new BookLibrary { BookId = bookToUpdate.Id, LibraryId = libraryId });
			}

			bookToUpdate.Id = request.Id;
			bookToUpdate.Title = request.Title;
			bookToUpdate.Description = request.Description;
			bookToUpdate.Pages = request.Pages;
			bookToUpdate.Published = request.Published;
			bookToUpdate.Language = request.Language;
			bookToUpdate.Country = request.Country;
			bookToUpdate.Image = request.Image;
			bookToUpdate.AuthorId = request.AuthorId;
			bookToUpdate.GenreId = request.GenreId;
			bookToUpdate.LastModified = DateTime.Now;
			bookToUpdate.BookLibraries = bookLibraries;

			_mockMapper.Setup(x => x.Map(request, bookToUpdate)).Returns(bookToUpdate);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			_mockRepository.Verify(x => x.SaveAsync(), Times.Once);
		}

		[Fact]
		public async Task Handle_Should_InvokeUpdateOnce_WhenRequestIsValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithAllSet()
				.Build();

			var bookToUpdate = new BookBuilder()
				.WithAllSet()
				.Build();

			_mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(bookToUpdate);

			var bookLibraries = new List<BookLibrary>();

			foreach (var libraryId in request.LibraryIds)
			{
				bookLibraries.Add(new BookLibrary { BookId = bookToUpdate.Id, LibraryId = libraryId });
			}

			bookToUpdate.Id = request.Id;
			bookToUpdate.Title = request.Title;
			bookToUpdate.Description = request.Description;
			bookToUpdate.Pages = request.Pages;
			bookToUpdate.Published = request.Published;
			bookToUpdate.Language = request.Language;
			bookToUpdate.Country = request.Country;
			bookToUpdate.Image = request.Image;
			bookToUpdate.AuthorId = request.AuthorId;
			bookToUpdate.GenreId = request.GenreId;
			bookToUpdate.LastModified = DateTime.Now;
			bookToUpdate.BookLibraries = bookLibraries;

			_mockMapper.Setup(x => x.Map(request, bookToUpdate)).Returns(bookToUpdate);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			_mockRepository.Verify(x => x.Update(bookToUpdate), Times.Once);
		}

		[Fact]
		public async Task Handle_Should_SetLastModifiedToCurrentDateAndTime_WhenRequestIsValid()
		{
			// Arrange
			var request = new UpdateBookCommandBuilder()
				.WithAllSet()
				.Build();

			var bookToUpdate = new BookBuilder()
				.WithAllSet()
				.Build();

			_mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(bookToUpdate);

			var bookLibraries = new List<BookLibrary>();

			foreach (var libraryId in request.LibraryIds)
			{
				bookLibraries.Add(new BookLibrary { BookId = bookToUpdate.Id, LibraryId = libraryId });
			}

			bookToUpdate.Id = request.Id;
			bookToUpdate.Title = request.Title;
			bookToUpdate.Description = request.Description;
			bookToUpdate.Pages = request.Pages;
			bookToUpdate.Published = request.Published;
			bookToUpdate.Language = request.Language;
			bookToUpdate.Country = request.Country;
			bookToUpdate.Image = request.Image;
			bookToUpdate.AuthorId = request.AuthorId;
			bookToUpdate.GenreId = request.GenreId;
			bookToUpdate.LastModified = DateTime.Now;
			bookToUpdate.BookLibraries = bookLibraries;

			_mockMapper.Setup(x => x.Map(request, bookToUpdate)).Returns(bookToUpdate);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

			// Act
			var result = await handler.Handle(request, default);

			// Assert
			bookToUpdate.LastModified.Should().NotBeNull();
			bookToUpdate.LastModified.Should().BeSameDateAs(DateTime.Now);
		}

		[Fact]
        public async Task Handle_Should_ReturnSuccessResultWithNoErrors_WhenRequestIsValid()
        {
            // Arrange
            var request = new UpdateBookCommandBuilder()
                .WithAllSet()
                .Build();

            var bookToUpdate = new BookBuilder()
                .WithAllSet()
                .Build();

            _mockRepository.Setup(x => x.GetAsync(request.Id)).ReturnsAsync(bookToUpdate);

            var bookLibraries = new List<BookLibrary>();

            foreach (var libraryId in request.LibraryIds)
            {
                bookLibraries.Add(new BookLibrary { BookId = bookToUpdate.Id, LibraryId = libraryId });
            }

			bookToUpdate.Id = request.Id;
			bookToUpdate.Title = request.Title;
			bookToUpdate.Description = request.Description;
			bookToUpdate.Pages = request.Pages;
			bookToUpdate.Published = request.Published;
			bookToUpdate.Language = request.Language;
			bookToUpdate.Country = request.Country;
			bookToUpdate.Image = request.Image;
			bookToUpdate.AuthorId = request.AuthorId;
			bookToUpdate.GenreId = request.GenreId;
			bookToUpdate.LastModified = DateTime.Now;
			bookToUpdate.BookLibraries = bookLibraries;

            _mockMapper.Setup(x => x.Map(request, bookToUpdate)).Returns(bookToUpdate);

			var handler = new UpdateBookCommandHandler(_mockRepository.Object, _mockMapper.Object);

            // Act
            var result = await handler.Handle(request, default);

            // Assert
            result.Succeeded.Should().BeTrue();
            result.Errors.Should().BeNull();
        }
    }
}