namespace Ebla.Application.Common.Responses
{
    public record UserResponse
    {
        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string[] Roles { get; set; }
    }
}