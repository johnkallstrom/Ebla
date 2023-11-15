namespace Ebla.Web.Services.Interfaces
{
    public interface IUserHttpService
    {
        Task<List<UserViewModel>> GetAllAsync(); 
    }
}
