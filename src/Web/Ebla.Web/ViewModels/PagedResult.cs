namespace Ebla.Web.ViewModels
{
    public record PagedResult<T>(
        bool Succeeded, 
        string[] Errors, 
        int PageNumber, 
        int PageSize, 
        int TotalPages,
        IEnumerable<T> Data);
}
