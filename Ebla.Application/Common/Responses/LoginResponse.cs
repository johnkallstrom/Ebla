namespace Ebla.Application.Common.Responses
{
    public record LoginResponse
    {
        public bool Succeeded { get; init; }
        public string[] Errors { get; init; }
        public string Token { get; set; }

        /// <summary>
        /// Returns a success login response
        /// </summary>
        /// <returns></returns>
        public static LoginResponse Success(string token)
        {
            return new LoginResponse
            {
                Succeeded = true,
                Errors = null,
                Token = token,
            };
        }

        /// <summary>
        /// Returns a failure login response
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public static LoginResponse Failure(string[] errors)
        {
            return new LoginResponse
            {
                Succeeded = false,
                Errors = errors,
                Token = null,
            };
        }
    }
}