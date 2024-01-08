namespace Ebla.Persistence
{
    public record InitialUser(
        string Username,
        string FirstName,
        string LastName,
        string Password,
        string Email,
        string[] Roles);
}
