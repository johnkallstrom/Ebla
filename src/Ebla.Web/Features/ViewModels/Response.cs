namespace Ebla.Web.Features.ViewModels
{
    public record Response<T>(bool Succeeded, string[] Errors, T Data);
}