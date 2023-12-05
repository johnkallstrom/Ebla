namespace Ebla.Persistence.Models
{
    public record InitialUser(
        string Username,
        string Password,
        string Email,
        string[] Roles);
}
