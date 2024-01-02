namespace Ebla.Application.Common
{
    public record Response
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }

        public static Response Success()
        {
            return new Response
            {
                Succeeded = true,
                Errors = null
            };
        }

        public static Response Failure(string[] errors)
        {
            return new Response
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }

    public record Response<T>
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public T Data { get; init; }

        public static Response<T> Success(T data)
        {
            return new Response<T>
            {
                Succeeded = true,
                Errors = null,
                Data = data
            };
        }

        public static Response<T> Failure(string[] errors)
        {
            return new Response<T>
            {
                Succeeded = false,
                Errors = errors,
                Data = default,
            };
        }
    }
}
