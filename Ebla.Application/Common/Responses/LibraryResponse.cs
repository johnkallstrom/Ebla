namespace Ebla.Application.Common.Responses
{
    public record LibraryResponse(
        int Id, 
        string Name, 
        DateTime? Established, 
        DateTime CreatedOn, 
        DateTime? LastModified, 
        List<LibraryCardResponse> LibraryCards);
}