namespace Ebla.Application.UseCases.Users.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response>
    {
        private readonly IIdentityService _identityService;

        public UpdateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                await _identityService.UpdateUserAsync(request.Id, request.Email, request.Roles.ToArray());
                return Response.Success();
            }
            else
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
                return Response.Failure(errors);
            }
        }
    }
}
