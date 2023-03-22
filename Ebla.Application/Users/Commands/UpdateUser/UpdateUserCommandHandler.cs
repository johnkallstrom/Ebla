namespace Ebla.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public UpdateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                await _identityService.UpdateUserAsync(request.Id, request.Email, request.Roles.ToArray());
                return Result.Success();
            }
            else
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
                return Result.Failure(errors);
            }
        }
    }
}
