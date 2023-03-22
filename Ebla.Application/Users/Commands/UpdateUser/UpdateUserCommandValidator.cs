namespace Ebla.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
