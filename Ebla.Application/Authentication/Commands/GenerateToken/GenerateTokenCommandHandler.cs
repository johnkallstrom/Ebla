namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
    {
        public Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
