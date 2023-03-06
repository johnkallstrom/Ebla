namespace Ebla.Infrastructure.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        public Task<string> GetJwtToken(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
