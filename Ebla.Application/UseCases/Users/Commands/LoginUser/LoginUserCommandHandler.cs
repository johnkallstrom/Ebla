namespace Ebla.Application.UseCases.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtProvider _jwtProvider;

        public LoginUserCommandHandler(IIdentityService identityService, IJwtProvider jwtProvider)
        {
            _identityService = identityService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var user = await _identityService.LoginAsync(request.Username, request.Password);
                    string token = _jwtProvider.GenerateToken(user);

                    return LoginResponse.Success(token);
                }
                catch (Exception ex)
                {
                    return LoginResponse.Failure(new string[] { ex.Message });
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return LoginResponse.Failure(errors);
        }
    }
}
