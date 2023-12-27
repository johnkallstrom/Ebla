namespace Ebla.Application.Authors.Responses
{
    public record AuthorSlimDto(
        int Id,
        string Name,
        DateTime Born,
        string Country,
        string Image);
}
