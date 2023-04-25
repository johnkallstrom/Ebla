﻿namespace Ebla.Application.Loans.Commands.UpdateLoan
{
    public class UpdateLoanCommandValidator : AbstractValidator<UpdateLoanCommand>
    {
        public UpdateLoanCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please enter a valid {PropertyName}");
            RuleFor(x => x.DueDate).NotNull().WithMessage("Please enter a valid date for {PropertyName}");
        }
    }
}