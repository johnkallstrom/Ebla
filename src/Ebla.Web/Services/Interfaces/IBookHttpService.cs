namespace Ebla.Web.Services.Interfaces
{
	public interface IBookHttpService
	{
		Task<IEnumerable<BookViewModel>> GetAllAsync();
	}
}
