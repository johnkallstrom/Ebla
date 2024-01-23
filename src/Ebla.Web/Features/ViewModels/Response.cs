namespace Ebla.Web.Features.ViewModels
{
    public record Response(bool Succeeded, string[] Errors);
    public record Response<T>(bool Succeeded, string[] Errors, T Data);
}