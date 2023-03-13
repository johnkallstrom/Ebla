namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommand : IRequest<IResult<string>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
