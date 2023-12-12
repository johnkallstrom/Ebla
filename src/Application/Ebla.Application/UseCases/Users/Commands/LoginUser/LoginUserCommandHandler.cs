namespace Ebla.Application.UseCases.Users.Commands
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Response<string>>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtProvider _jwtProvider;

        public LoginUserCommandHandler(IIdentityService identityService, IJwtProvider jwtProvider)
        {
            _identityService = identityService;
            _jwtProvider = jwtProvider;
        }

        public async Task<Response<string>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                try
                {
                    bool success = await _identityService.LoginAsync(request.Username, request.Password);
                    if (success)
                    {
                        var user = await _identityService.GetUserAsync(request.Username);
                        var roles = await _identityService.GetUserRolesAsync(user);

                        string token = _jwtProvider.GenerateToken(user, roles);

                        return Response<string>.Success(token);
                    }
                }
                catch (Exception ex)
                {
                    return Response<string>.Failure(new string[] { ex.Message });
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response<string>.Failure(errors);
        }
    }
}
