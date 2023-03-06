namespace Ebla.Infrastructure.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        public Task<string> GenerateToken(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
