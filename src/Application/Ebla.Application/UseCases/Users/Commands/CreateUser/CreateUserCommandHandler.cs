namespace Ebla.Application.UseCases.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<Guid>>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Response<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _identityService.GetUserAsync(request.Username);
                if (user is null)
                {
                    var userId = await _identityService.CreateUserAsync(request.Username, request.Password, request.Roles.ToArray());
                    return Response<Guid>.Success(userId);
                }
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return Response<Guid>.Failure(errors);
        }
    }
}