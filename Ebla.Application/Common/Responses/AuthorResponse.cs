namespace Ebla.Application.Common.Responses
{
    public record AuthorResponse(
        int Id, 
        string Name, 
        string Description, 
        DateTime Born, 
        string Country, 
        string ImageLink, 
        string Wikipedia, 
        DateTime CreatedOn, 
        DateTime? LastModified);
}