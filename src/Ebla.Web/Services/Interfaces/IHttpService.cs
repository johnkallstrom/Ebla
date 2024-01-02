namespace Ebla.Web.Services.Interfaces
{
    public interface IHttpService
    {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<HttpResponseMessage> PostAsync(string uri, object data);
    }
}