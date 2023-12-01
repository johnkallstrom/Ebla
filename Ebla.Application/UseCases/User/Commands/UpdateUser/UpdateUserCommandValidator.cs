namespace Ebla.Application.UseCases.User.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
