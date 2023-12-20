namespace Ebla.Web.ViewModels
{
    public record PagedResult<T>
    {
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}