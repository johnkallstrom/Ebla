namespace Ebla.Application.Authentication.Commands.GenerateToken
{
    public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
    {
        public GenerateTokenCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Please enter a valid {PropertyName}, must be atleast 8 characters in length");
        }
    }
}
