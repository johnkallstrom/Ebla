namespace Ebla.Web.ViewModels
{
    public record Response<T>(bool Succeeded, string[] Errors, T Data);
}