namespace Ebla.Application.Common
{
    public record Response
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }

        /// <summary>
        /// Returns a success response
        /// </summary>
        /// <returns></returns>
        public static Response Success()
        {
            return new Response
            {
                Succeeded = true,
                Errors = null
            };
        }

        /// <summary>
        /// Returns a failure response
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a success response with data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Response<T> Success(T data)
        {
            return new Response<T>
            {
                Succeeded = true,
                Errors = null,
                Data = data
            };
        }

        /// <summary>
        /// Returns a failure response
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
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
