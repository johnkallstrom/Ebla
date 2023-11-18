namespace Ebla.Application.Common.Models
{
    public record LoginResult
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public string Token { get; set; }
        public UserDto User { get; set; }

        /// <summary>
        /// Returns a success login result
        /// </summary>
        /// <returns></returns>
        public static LoginResult Success(string token, UserDto user)
        {
            return new LoginResult
            {
                Succeeded = true,
                Errors = null,
                Token = token,
                User = user
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
                Errors = errors,
                Token = null,
                User = null
            };
        }
    }
}
