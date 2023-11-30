using Ebla.Application.Interfaces;

namespace Ebla.Application.Loans.Queries.GetLoansByUserId
{
    public class GetLoansByUserIdQueryHandler : IRequestHandler<GetLoansByUserIdQuery, IEnumerable<LoanResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _repository;

        public GetLoansByUserIdQueryHandler(
            IMapper mapper, 
            ILoanRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<LoanResponse>> Handle(GetLoansByUserIdQuery request, CancellationToken cancellationToken)
        {
            var loans = await _repository.GetLoansByUserIdAsync(request.UserId);

            return _mapper.Map<IEnumerable<LoanResponse>>(loans);
        }
    }
}
