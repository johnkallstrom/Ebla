namespace Ebla.Application.UseCases.User.Commands
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
        }
    }
}
