﻿namespace Ebla.Application.UseCases.Authors.Queries
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, PagedResponse<AuthorSlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Author> _repository;

        public GetAuthorsQueryHandler(IGenericRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<AuthorSlimDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAuthorsQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                int pageNumber = request.PageNumber;
                int pageSize = request.PageSize;
                int totalAuthors = await _repository.GetTotalAsync();

                var authors = await _repository.GetPagedAsync(pageNumber, pageSize);
                var dtos = _mapper.Map<IEnumerable<AuthorSlimDto>>(authors);

                return PagedResponse<AuthorSlimDto>.Success(pageNumber, pageSize, (totalAuthors / pageSize), dtos);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return PagedResponse<AuthorSlimDto>.Failure(errors);
        }
    }
}