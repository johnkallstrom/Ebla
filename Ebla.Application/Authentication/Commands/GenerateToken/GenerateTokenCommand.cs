namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
