namespace Ebla.Persistence.Data.Models
{
    public record InitialUser(
        string Username, 
        string Password, 
        string Email, 
        string[] Roles);
}
