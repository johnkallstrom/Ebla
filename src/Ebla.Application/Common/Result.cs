namespace Ebla.Application.Common
{
    public record Result
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }

        public static Result Success()
        {
            return new Result
            {
                Succeeded = true,
                Errors = null
            };
        }

        public static Result Failure(string[] errors)
        {
            return new Result
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }

    public record Result<T>
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public T Data { get; init; }

        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Succeeded = true,
                Errors = null,
                Data = data
            };
        }

        public static Result<T> Failure(string[] errors)
        {
            return new Result<T>
            {
                Succeeded = false,
                Errors = errors,
                Data = default,
            };
        }
    }
}
