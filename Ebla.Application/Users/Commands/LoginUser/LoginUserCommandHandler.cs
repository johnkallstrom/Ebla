namespace Ebla.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IResult>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtProvider _jwtProvider;

        public LoginUserCommandHandler(IIdentityService identityService, IJwtProvider jwtProvider)
        {
            _identityService = identityService;
            _jwtProvider = jwtProvider;
        }

        public async Task<IResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var loginResult = await _identityService.LoginAsync(request.Username, request.Password);
                if (loginResult.Succeeded)
                {
                    var user = await _identityService.GetUserAsync(request.Username);

                    var token = _jwtProvider.GenerateToken(user);
                    return LoginResult.Success(token);
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return LoginResult.Failure(errors);
        }
    }
}
