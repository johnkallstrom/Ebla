﻿namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommandHandler : IRequestHandler<GenerateTokenCommand, Result<string>>
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

        public async Task<Result<string>> Handle(GenerateTokenCommand request, CancellationToken cancellationToken)
        {
            var validator = new GenerateTokenCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var loginResult = await _identityService.LoginAsync(request.Username, request.Password);
                if (loginResult.Succeeded)
                {
                    var user = await _identityService.GetUserAsync(request.Username);

                    var token = _jwtProvider.GenerateToken(user);
                    return Result<string>.Success(token);
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Result<string>.Failure(errors);
        }
    }
}
