namespace Ebla.Application.Common.Responses
{
    public record LibrarySlimResponse(
        int Id, 
        string Name, 
        DateTime? Established);
}