namespace Ebla.Application.Common.Models
{
    public record LoginResult : IResult
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public string Token { get; set; }

        /// <summary>
        /// Returns a success login result
        /// </summary>
        /// <returns></returns>
        public static LoginResult Success(string token)
        {
            return new LoginResult
            {
                Succeeded = true,
                Errors = null,
                Token = token
            };
        }

        /// <summary>
        /// Returns a failure login result
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static LoginResult Failure(string[] errors)
        {
            return new LoginResult
            {
                Succeeded = false,
                Errors = errors
            };
        }
    }
}
