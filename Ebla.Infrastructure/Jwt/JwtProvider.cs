namespace Ebla.Infrastructure.Jwt
{
    public class JwtProvider : IJwtProvider
    {
        public string GenerateToken(UserDto user)
        {
            var issuer = "http://localhost:5121/index.html";
            var audience = "http://localhost:5121/index.html";
            var key = Encoding.UTF8.GetBytes("25xfWHTsdWIj5duLp0tw");

            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Username", user.Username),
                new Claim("Email", user.Email)
            };

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(60),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(securityTokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
