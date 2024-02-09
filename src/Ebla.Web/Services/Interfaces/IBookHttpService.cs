namespace Ebla.Web.Services.Interfaces
{
	public interface IBookHttpService
	{
		Task<BookViewModel> GetAsync(int bookId);
		Task<IEnumerable<BookViewModel>> GetAllAsync();
	}
}
