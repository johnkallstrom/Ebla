namespace Ebla.Application.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Please enter a valid {PropertyName}, must be atleast 8 characters in length");
        }
    }
}
