namespace Ebla.Application.Reviews.Queries.GetReviewsByBookId
{
    public class GetReviewsByBookIdQueryHandler : IRequestHandler<GetReviewsByBookIdQuery, IEnumerable<ReviewDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _repository;

        public GetReviewsByBookIdQueryHandler(IReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByBookIdQuery request, CancellationToken cancellationToken)
        {
            var reviews = await _repository.GetReviewListByBookIdAsync(request.BookId);

            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }
    }
}
