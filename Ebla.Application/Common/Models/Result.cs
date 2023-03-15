namespace Ebla.Application.Common.Models
{
    public record Result : IResult
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }

        /// <summary>
        /// Returns a success result
        /// </summary>
        /// <returns></returns>
        public static Result Success()
        {
            return new Result
            {
                Succeeded = true,
                Errors = null
            };
        }

        /// <summary>
        /// Returns a failure result
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static Result Failure(string[] errors)
        {
            return new Result
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }

    public record Result<T> : IResult<T>
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public T Data { get; init; }

        /// <summary>
        /// Returns a success result with data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Result<T> Success(T data)
        {
            return new Result<T>
            {
                Succeeded = true,
                Errors = null,
                Data = data
            };
        }

        /// <summary>
        /// Returns a failure result
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
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
