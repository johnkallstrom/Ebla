namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, IResult<string>>
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

        public async Task<IResult<string>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<string>();

            var validator = new GenerateTokenCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var loginResult = await _identityService.LoginAsync(request.Username, request.Password);
                if (loginResult.Succeeded)
                {
                    var user = await _identityService.GetUserAsync(request.Username);

                    var token = _jwtProvider.GenerateToken(user);
                    result.Value = token;
                    result.Success();
                }
            }
            else
            {
                result.Failure(validationResult.Errors.Select(x => x.ErrorMessage).ToArray());
            }

            return result;
        }
    }
}
