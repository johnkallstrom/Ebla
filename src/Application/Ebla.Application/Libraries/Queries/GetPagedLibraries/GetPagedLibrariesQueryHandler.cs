namespace Ebla.Application.Libraries.Queries
{
    public class GetPagedLibrariesQueryHandler : IRequestHandler<GetPagedLibrariesQuery, PagedResponse<LibrarySlimDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Library> _repository;

        public GetPagedLibrariesQueryHandler(IMapper mapper, IGenericRepository<Library> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PagedResponse<LibrarySlimDto>> Handle(GetPagedLibrariesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetPagedLibrariesQueryValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid)
            {
                int pageNumber = request.PageNumber;
                int pageSize = request.PageSize;

                int totalRecords = await _repository.GetTotalAsync();
                int totalPages = Convert.ToInt32(Math.Ceiling((double)totalRecords / pageSize));

                var libraries = await _repository.GetPagedAsync(pageNumber, pageSize);
                var dtos = _mapper.Map<IEnumerable<LibrarySlimDto>>(libraries);

                return PagedResponse<LibrarySlimDto>.Success(pageNumber, pageSize, totalPages, totalRecords, dtos);
            }

            var errors = validationResult.Errors?.Select(x => x.ErrorMessage).ToArray();
            return PagedResponse<LibrarySlimDto>.Failure(errors);
        }
    }
}
