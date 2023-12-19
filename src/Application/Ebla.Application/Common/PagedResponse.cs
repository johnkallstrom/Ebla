namespace Ebla.Application.Common
{
    public record PagedResponse<T>
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalPages { get; init; }
        public IEnumerable<T> Data { get; init; }

        public static PagedResponse<T> Success(
            int pageNumber, 
            int pageSize, 
            int totalPages, 
            IEnumerable<T> data)
        {
            return new PagedResponse<T>
            {
                Succeeded = true,
                Errors = null,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                Data = data
            };
        }

        public static PagedResponse<T> Failure(string[] errors)
        {
            return new PagedResponse<T>
            {
                Succeeded = false,
                Errors = errors,
            };
        }
    }
}