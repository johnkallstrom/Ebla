namespace Ebla.Application.Interfaces
{
    public interface IIdentityService
    {
        Task AuthorizeAsync(string username, string password);
    }
}
