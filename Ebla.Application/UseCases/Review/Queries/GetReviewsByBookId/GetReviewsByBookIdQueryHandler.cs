namespace Ebla.Application.UseCases.Review.Queries
{
    public class GetReviewsByBookIdQueryHandler : IRequestHandler<GetReviewsByBookIdQuery, IEnumerable<ReviewResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _repository;

        public GetReviewsByBookIdQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewResponse>> Handle(GetReviewsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetReviewListByBookIdAsync(request.BookId);

            return _mapper.Map<IEnumerable<ReviewResponse>>(reviews);
        }
    }
}
