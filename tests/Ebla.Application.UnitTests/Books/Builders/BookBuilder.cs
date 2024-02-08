namespace Ebla.Application.UnitTests.Books.Builders
{
	public class BookBuilder
	{
		private Book _book = new Book();

		public BookBuilder WithId(int id)
		{
			_book.Id = id;
			return this;
		}

		public BookBuilder WithTitle(string title)
		{
			_book.Title = title;
			return this;
		}

		public BookBuilder WithDescription(string description)
		{
			_book.Description = description;
			return this;
		}

		public BookBuilder WithPages(int pages)
		{
			_book.Pages = pages;
			return this;
		}

		public BookBuilder WithPublished(DateTime published)
		{
			_book.Published = published;
			return this;
		}

		public BookBuilder WithLanguage(string language)
		{
			_book.Language = language;
			return this;
		}

		public BookBuilder WithCountry(string country)
		{
			_book.Country = country;
			return this;
		}

		public BookBuilder WithImage(string image)
		{
			_book.Image = image;
			return this;
		}

		public BookBuilder WithAuthor(int authorId)
		{
			_book.AuthorId = authorId;
			return this;
		}

		public BookBuilder WithGenre(int genreId)
		{
			_book.GenreId = genreId;
			return this;
		}

		public BookBuilder WithBookLibraries(List<BookLibrary> bookLibraries)
		{
			_book.BookLibraries = bookLibraries;
			return this;
		}

		public BookBuilder WithReviews(List<Review> reviews)
		{
			_book.Reviews = reviews;
			return this;
		}

		public BookBuilder WithReservations(List<Reservation> reservations)
		{
			_book.Reservations = reservations;
			return this;
		}

		public BookBuilder WithCreatedOn(DateTime createdOn)
		{
			_book.CreatedOn = createdOn;
			return this;
		}

		public BookBuilder WithLastModified(DateTime? lastModified)
		{
			_book.LastModified = lastModified;
			return this;
		}

		/// <summary>
		/// Set all properties with sample data for testing purposes
		/// </summary>
		/// <returns></returns>
		public BookBuilder WithAllSet()
		{
			_book.Id = 1;
			_book.Title = "Rendezvous with Rama";
			_book.Description = "Rendezvous with Rama is a science fiction novel by British writer Arthur C. Clarke first published in 1973. Set in the 2130s, the story involves a 50-by-20-kilometre (31 by 12 mi) cylindrical alien starship that enters the Solar System. The story is told from the point of view of a group of human explorers who intercept the ship in an attempt to unlock its mysteries. The novel won both the Hugo[4] and Nebula[5] awards upon its release, and is regarded as one of the cornerstones in Clarke's bibliography. The concept was later extended with several sequels, written by Clarke and Gentry Lee.";
			_book.Pages = 256;
			_book.Published = new DateTime(1973, 6, 1);
			_book.Language = "English";
			_book.Country = "United Kingdom";
			_book.Image = "https://upload.wikimedia.org/wikipedia/en/e/e1/Rama_copy.jpg";
			_book.AuthorId = 1;
			_book.GenreId = 1;
			_book.CreatedOn = DateTime.Now;
			_book.LastModified = null;
			_book.BookLibraries = new List<BookLibrary>
			{
				new BookLibrary { BookId = 1, LibraryId = 1 },
				new BookLibrary { BookId = 1, LibraryId = 2 },
				new BookLibrary { BookId = 1, LibraryId = 3 },
				new BookLibrary { BookId = 1, LibraryId = 4 },
				new BookLibrary { BookId = 1, LibraryId = 5 }
			};

			return this;
		}

		public Book Build()
		{
			return _book;
		}
	}
}