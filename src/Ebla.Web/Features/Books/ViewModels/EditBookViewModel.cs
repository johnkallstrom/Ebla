namespace Ebla.Web.Features.Books.ViewModels
{
	public class EditBookViewModel
	{
		[Label("Id")]
		[Required(ErrorMessage = "Please enter an id")]
        public int Id { get; set; }

        [Label("Title")]
		[Required(ErrorMessage = "Please enter a title")]
		[DataType(DataType.Text)]
		public string Title { get; set; }

		[Label("Description")]
		[Required(ErrorMessage = "Please enter a description")]
		[DataType(DataType.Text)]
		public string Description { get; set; }

		[Label("Pages")]
		[Required(ErrorMessage = "Please enter pages")]
		public int Pages { get; set; } = 1;

		[Label("Published")]
		[Required(ErrorMessage = "Please enter a valid date")]
		[DataType(DataType.Date)]
		public DateTime? Published { get; set; }

		[Label("Language")]
		[Required(ErrorMessage = "Please enter a language")]
		[DataType(DataType.Text)]
		public string Language { get; set; }

		[Label("Country")]
		[Required(ErrorMessage = "Please enter a country")]
		[DataType(DataType.Text)]
		public string Country { get; set; }

		[Label("Image")]
		[Required(ErrorMessage = "Please enter an image url")]
		[DataType(DataType.ImageUrl)]
		public string Image { get; set; }

		public int AuthorId { get; set; }
		public int GenreId { get; set; }
		public int[] LibraryIds { get; set; }
	}
}
