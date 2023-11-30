using Ebla.Application.Common.Results;
using Ebla.Application.Interfaces;

namespace Ebla.Application.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResult>
    {
        private readonly IIdentityService _identityService;
        private readonly IJwtProvider _jwtProvider;

        public LoginUserCommandHandler(IIdentityService identityService, IJwtProvider jwtProvider)
        {
            _identityService = identityService;
            _jwtProvider = jwtProvider;
        }

        public async Task<LoginResult> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var user = await _identityService.LoginAsync(request.Username, request.Password);
                    string token = _jwtProvider.GenerateToken(user);

                    return LoginResult.Success(token);
                }
                catch (Exception ex)
                {
                    return LoginResult.Failure(new string[] { ex.Message });
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return LoginResult.Failure(errors);
        }
    }
}
