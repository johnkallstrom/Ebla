namespace Ebla.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, IResult<Guid>>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<IResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<Guid>();

            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var user = await _identityService.GetUserAsync(request.Username);
                if (user is null)
                {
                    var id = await _identityService.CreateUserAsync(request.Username, request.Password, request.Roles.ToArray());

                    result.Value = id;
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