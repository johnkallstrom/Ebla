namespace Ebla.Application.UnitTests.Books.Builders
{
	public class UpdateBookCommandBuilder
	{
		private UpdateBookCommand _command = new UpdateBookCommand();

		public UpdateBookCommandBuilder WithId(int id)
		{
			_command.Id = id;
			return this;
		}

		public UpdateBookCommandBuilder WithTitle(string title)
		{

			_command.Title = title;
			return this;
		}

		public UpdateBookCommandBuilder WithDescription(string description)
		{
			_command.Description = description;
			return this;
		}

		public UpdateBookCommandBuilder WithPages(int pages)
		{
			_command.Pages = pages;
			return this;
		}

		public UpdateBookCommandBuilder WithPublished(DateTime published)
		{
			_command.Published = published;
			return this;
		}

		public UpdateBookCommandBuilder WithLanguage(string language)
		{
			_command.Language = language;
			return this;
		}

		public UpdateBookCommandBuilder WithCountry(string country)
		{
			_command.Country = country;
			return this;
		}

		public UpdateBookCommandBuilder WithImage(string image)
		{
			_command.Image = image;
			return this;
		}

		public UpdateBookCommandBuilder WithAuthor(int authorId)
		{
			_command.AuthorId = authorId;
			return this;
		}

		public UpdateBookCommandBuilder WithGenre(int genreId)
		{
			_command.GenreId = genreId;
			return this;
		}

		public UpdateBookCommandBuilder WithLibraries(int[] libraryIds)
		{
			_command.LibraryIds = libraryIds;
			return this;
		}

		/// <summary>
		/// Set all properties with sample data for testing purposes
		/// </summary>
		/// <returns></returns>
		public UpdateBookCommandBuilder WithAllSet()
		{
			_command.Id = 1;
			_command.Title = "Updated Title";
			_command.Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque urna nisl, condimentum in lacus in, faucibus lacinia tortor. Pellentesque sed convallis dolor, gravida aliquam quam.";
			_command.Pages = 256;
			_command.Published = new DateTime(1973, 6, 1);
			_command.Language = "English";
			_command.Country = "United Kingdom";
			_command.Image = "https://upload.wikimedia.org/wikipedia/en/f/fc/TheDispossed%281stEdHardcover%29.jpg";
			_command.AuthorId = 2;
			_command.GenreId = 1;
			_command.LibraryIds = [1, 2, 5];

			return this;
		}

		public UpdateBookCommand Build()
		{
			return _command;
		}
	}
}