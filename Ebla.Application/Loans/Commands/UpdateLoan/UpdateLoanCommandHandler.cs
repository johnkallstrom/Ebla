using Ebla.Application.Interfaces;

namespace Ebla.Application.Loans.Commands.UpdateLoan
{
    public class UpdateLoanCommandHandler : IRequestHandler<UpdateLoanCommand, Result>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Loan> _genericRepository;

        public UpdateLoanCommandHandler(
            IGenericRepository<Loan> genericRepository, 
            IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<Result> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLoanCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                var loanToUpdate = await _genericRepository.GetByIdAsync(request.Id);
                if (loanToUpdate is null)
                {
                    throw new NotFoundException(nameof(loanToUpdate), request.Id);
                }

                loanToUpdate = _mapper.Map(request, loanToUpdate);
                loanToUpdate.LastModified = DateTime.Now;

                _genericRepository.Update(loanToUpdate);
                await _genericRepository.SaveAsync();

                return Result.Success();
            }

            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToArray();
            return Result.Failure(errors);
        }
    }
}
