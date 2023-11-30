namespace Ebla.Application.Common.Responses
{
    public record AuthorSlimResponse(
        int Id, 
        string Name, 
        DateTime Born, 
        string Country, 
        string ImageLink);
}
