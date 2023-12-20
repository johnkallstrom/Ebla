namespace Ebla.Web.ViewModels
{
    public record Result<T>(bool Succeeded, string[] Errors, T Data);
}