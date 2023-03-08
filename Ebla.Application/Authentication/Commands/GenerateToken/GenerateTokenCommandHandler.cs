namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, string>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtProvider _jwtProvider;

        public GenerateTokenCommandHandler(
            IJwtProvider jwtProvider, 
            IIdentityService identityService)
        {
            _jwtProvider = jwtProvider;
            _identityService = identityService;
        }

        public async Task<string> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var result = await _identityService.LoginAsync(request.Username, request.Password);
            if (result.Succeeded)
            {
                var user = await _identityService.GetUserAsync(request.Username);

                var token = _jwtProvider.GenerateToken(user);
                return token;
            }

            return null;
        }
    }
}
