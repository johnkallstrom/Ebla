namespace Ebla.Infrastructure.Persistence.Helpers
{
    public record InitialUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}
