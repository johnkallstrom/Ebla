namespace Ebla.Application.Common.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
